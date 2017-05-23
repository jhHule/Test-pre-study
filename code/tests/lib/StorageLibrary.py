import sys
import glob
#sys.path.append('lib')
#sys.path.insert(0, glob.glob('../../lib/py/build/lib*')[0])


from storage import StorageService
from storage.ttypes import StoragePoint

from thrift import Thrift
from thrift.transport import TSocket
from thrift.transport import TTransport
from thrift.transport.TTransport import TTransportException
from thrift.protocol import TBinaryProtocol

class StorageLibrary(object):

    def __init__(self):
        try:
            # Make socket
            self.transport = TSocket.TSocket('localhost', 9090)
            # Buffering is critical. Raw sockets are very slow
            self.transport = TTransport.TBufferedTransport(self.transport)
            # Wrap in a protocol
            self.protocol = TBinaryProtocol.TBinaryProtocol(self.transport)
            # Create a client to use the protocol encoder
            self.client = StorageService.Client(self.protocol)
            # Connect!
            self.transport.open()
        except TTransportException:
            raise AssertionError("Could not connect to Storage")


    def Close(self):
        self.transport.close()

    def read_storage_point_value(self, id):
        numeric_id = int(id)
        return self.client.read(numeric_id)

    def write_storage_point_value(self, id, value):
        numeric_id = int(id)
        return self.client.write(numeric_id, value)

    def verify_write_and_read(self, id, value):
        numeric_id = int(id)
        r1 = self.client.read(numeric_id)
        self.client.write(numeric_id, value)
        r2 = self.client.read(numeric_id)
        if not r2 == value:
            raise AssertionError("write read failed")


if __name__ == "__main__":
    app = StorageLibrary()
    app.client.ping()
    app.write_storage_point_value(0, "new value")
    print("value: " + app.read_storage_point_value(0))
    app.Close()