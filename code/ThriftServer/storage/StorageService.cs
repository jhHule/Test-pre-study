/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace storage
{
  public partial class StorageService {
    public interface ISync {
      void ping();
      List<StoragePoint> storagePoints();
      string read(int id);
      bool write(int id, string @value);
      void close();
    }

    public interface Iface : ISync {
      #if SILVERLIGHT
      IAsyncResult Begin_ping(AsyncCallback callback, object state);
      void End_ping(IAsyncResult asyncResult);
      #endif
      #if SILVERLIGHT
      IAsyncResult Begin_storagePoints(AsyncCallback callback, object state);
      List<StoragePoint> End_storagePoints(IAsyncResult asyncResult);
      #endif
      #if SILVERLIGHT
      IAsyncResult Begin_read(AsyncCallback callback, object state, int id);
      string End_read(IAsyncResult asyncResult);
      #endif
      #if SILVERLIGHT
      IAsyncResult Begin_write(AsyncCallback callback, object state, int id, string @value);
      bool End_write(IAsyncResult asyncResult);
      #endif
      #if SILVERLIGHT
      IAsyncResult Begin_close(AsyncCallback callback, object state);
      void End_close(IAsyncResult asyncResult);
      #endif
    }

    public class Client : IDisposable, Iface {
      public Client(TProtocol prot) : this(prot, prot)
      {
      }

      public Client(TProtocol iprot, TProtocol oprot)
      {
        iprot_ = iprot;
        oprot_ = oprot;
      }

      protected TProtocol iprot_;
      protected TProtocol oprot_;
      protected int seqid_;

      public TProtocol InputProtocol
      {
        get { return iprot_; }
      }
      public TProtocol OutputProtocol
      {
        get { return oprot_; }
      }


      #region " IDisposable Support "
      private bool _IsDisposed;

      // IDisposable
      public void Dispose()
      {
        Dispose(true);
      }
      

      protected virtual void Dispose(bool disposing)
      {
        if (!_IsDisposed)
        {
          if (disposing)
          {
            if (iprot_ != null)
            {
              ((IDisposable)iprot_).Dispose();
            }
            if (oprot_ != null)
            {
              ((IDisposable)oprot_).Dispose();
            }
          }
        }
        _IsDisposed = true;
      }
      #endregion


      
      #if SILVERLIGHT
      public IAsyncResult Begin_ping(AsyncCallback callback, object state)
      {
        return send_ping(callback, state);
      }

      public void End_ping(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        recv_ping();
      }

      #endif

      public void ping()
      {
        #if !SILVERLIGHT
        send_ping();
        recv_ping();

        #else
        var asyncResult = Begin_ping(null, null);
        End_ping(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_ping(AsyncCallback callback, object state)
      #else
      public void send_ping()
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("ping", TMessageType.Call, seqid_));
        ping_args args = new ping_args();
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public void recv_ping()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        ping_result result = new ping_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        return;
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_storagePoints(AsyncCallback callback, object state)
      {
        return send_storagePoints(callback, state);
      }

      public List<StoragePoint> End_storagePoints(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_storagePoints();
      }

      #endif

      public List<StoragePoint> storagePoints()
      {
        #if !SILVERLIGHT
        send_storagePoints();
        return recv_storagePoints();

        #else
        var asyncResult = Begin_storagePoints(null, null);
        return End_storagePoints(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_storagePoints(AsyncCallback callback, object state)
      #else
      public void send_storagePoints()
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("storagePoints", TMessageType.Call, seqid_));
        storagePoints_args args = new storagePoints_args();
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public List<StoragePoint> recv_storagePoints()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        storagePoints_result result = new storagePoints_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "storagePoints failed: unknown result");
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_read(AsyncCallback callback, object state, int id)
      {
        return send_read(callback, state, id);
      }

      public string End_read(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_read();
      }

      #endif

      public string read(int id)
      {
        #if !SILVERLIGHT
        send_read(id);
        return recv_read();

        #else
        var asyncResult = Begin_read(null, null, id);
        return End_read(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_read(AsyncCallback callback, object state, int id)
      #else
      public void send_read(int id)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("read", TMessageType.Call, seqid_));
        read_args args = new read_args();
        args.Id = id;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public string recv_read()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        read_result result = new read_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "read failed: unknown result");
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_write(AsyncCallback callback, object state, int id, string @value)
      {
        return send_write(callback, state, id, @value);
      }

      public bool End_write(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_write();
      }

      #endif

      public bool write(int id, string @value)
      {
        #if !SILVERLIGHT
        send_write(id, @value);
        return recv_write();

        #else
        var asyncResult = Begin_write(null, null, id, @value);
        return End_write(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_write(AsyncCallback callback, object state, int id, string @value)
      #else
      public void send_write(int id, string @value)
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("write", TMessageType.Call, seqid_));
        write_args args = new write_args();
        args.Id = id;
        args.Value = @value;
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public bool recv_write()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        write_result result = new write_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        if (result.__isset.success) {
          return result.Success;
        }
        throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "write failed: unknown result");
      }

      
      #if SILVERLIGHT
      public IAsyncResult Begin_close(AsyncCallback callback, object state)
      {
        return send_close(callback, state);
      }

      public void End_close(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        recv_close();
      }

      #endif

      public void close()
      {
        #if !SILVERLIGHT
        send_close();
        recv_close();

        #else
        var asyncResult = Begin_close(null, null);
        End_close(asyncResult);

        #endif
      }
      #if SILVERLIGHT
      public IAsyncResult send_close(AsyncCallback callback, object state)
      #else
      public void send_close()
      #endif
      {
        oprot_.WriteMessageBegin(new TMessage("close", TMessageType.Call, seqid_));
        close_args args = new close_args();
        args.Write(oprot_);
        oprot_.WriteMessageEnd();
        #if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
        #else
        oprot_.Transport.Flush();
        #endif
      }

      public void recv_close()
      {
        TMessage msg = iprot_.ReadMessageBegin();
        if (msg.Type == TMessageType.Exception) {
          TApplicationException x = TApplicationException.Read(iprot_);
          iprot_.ReadMessageEnd();
          throw x;
        }
        close_result result = new close_result();
        result.Read(iprot_);
        iprot_.ReadMessageEnd();
        return;
      }

    }
    public class Processor : TProcessor {
      public Processor(ISync iface)
      {
        iface_ = iface;
        processMap_["ping"] = ping_Process;
        processMap_["storagePoints"] = storagePoints_Process;
        processMap_["read"] = read_Process;
        processMap_["write"] = write_Process;
        processMap_["close"] = close_Process;
      }

      protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
      private ISync iface_;
      protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

      public bool Process(TProtocol iprot, TProtocol oprot)
      {
        try
        {
          TMessage msg = iprot.ReadMessageBegin();
          ProcessFunction fn;
          processMap_.TryGetValue(msg.Name, out fn);
          if (fn == null) {
            TProtocolUtil.Skip(iprot, TType.Struct);
            iprot.ReadMessageEnd();
            TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
            oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
            x.Write(oprot);
            oprot.WriteMessageEnd();
            oprot.Transport.Flush();
            return true;
          }
          fn(msg.SeqID, iprot, oprot);
        }
        catch (IOException)
        {
          return false;
        }
        return true;
      }

      public void ping_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        ping_args args = new ping_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        ping_result result = new ping_result();
        try
        {
          iface_.ping();
          oprot.WriteMessageBegin(new TMessage("ping", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("ping", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void storagePoints_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        storagePoints_args args = new storagePoints_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        storagePoints_result result = new storagePoints_result();
        try
        {
          result.Success = iface_.storagePoints();
          oprot.WriteMessageBegin(new TMessage("storagePoints", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("storagePoints", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void read_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        read_args args = new read_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        read_result result = new read_result();
        try
        {
          result.Success = iface_.read(args.Id);
          oprot.WriteMessageBegin(new TMessage("read", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("read", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void write_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        write_args args = new write_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        write_result result = new write_result();
        try
        {
          result.Success = iface_.write(args.Id, args.Value);
          oprot.WriteMessageBegin(new TMessage("write", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("write", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

      public void close_Process(int seqid, TProtocol iprot, TProtocol oprot)
      {
        close_args args = new close_args();
        args.Read(iprot);
        iprot.ReadMessageEnd();
        close_result result = new close_result();
        try
        {
          iface_.close();
          oprot.WriteMessageBegin(new TMessage("close", TMessageType.Reply, seqid)); 
          result.Write(oprot);
        }
        catch (TTransportException)
        {
          throw;
        }
        catch (Exception ex)
        {
          Console.Error.WriteLine("Error occurred in processor:");
          Console.Error.WriteLine(ex.ToString());
          TApplicationException x = new TApplicationException        (TApplicationException.ExceptionType.InternalError," Internal error.");
          oprot.WriteMessageBegin(new TMessage("close", TMessageType.Exception, seqid));
          x.Write(oprot);
        }
        oprot.WriteMessageEnd();
        oprot.Transport.Flush();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class ping_args : TBase
    {

      public ping_args() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("ping_args");
          oprot.WriteStructBegin(struc);
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("ping_args(");
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class ping_result : TBase
    {

      public ping_result() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("ping_result");
          oprot.WriteStructBegin(struc);

          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("ping_result(");
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class storagePoints_args : TBase
    {

      public storagePoints_args() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("storagePoints_args");
          oprot.WriteStructBegin(struc);
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("storagePoints_args(");
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class storagePoints_result : TBase
    {
      private List<StoragePoint> _success;

      public List<StoragePoint> Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public storagePoints_result() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              case 0:
                if (field.Type == TType.List) {
                  {
                    Success = new List<StoragePoint>();
                    TList _list0 = iprot.ReadListBegin();
                    for( int _i1 = 0; _i1 < _list0.Count; ++_i1)
                    {
                      StoragePoint _elem2;
                      _elem2 = new StoragePoint();
                      _elem2.Read(iprot);
                      Success.Add(_elem2);
                    }
                    iprot.ReadListEnd();
                  }
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("storagePoints_result");
          oprot.WriteStructBegin(struc);
          TField field = new TField();

          if (this.__isset.success) {
            if (Success != null) {
              field.Name = "Success";
              field.Type = TType.List;
              field.ID = 0;
              oprot.WriteFieldBegin(field);
              {
                oprot.WriteListBegin(new TList(TType.Struct, Success.Count));
                foreach (StoragePoint _iter3 in Success)
                {
                  _iter3.Write(oprot);
                }
                oprot.WriteListEnd();
              }
              oprot.WriteFieldEnd();
            }
          }
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("storagePoints_result(");
        bool __first = true;
        if (Success != null && __isset.success) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Success: ");
          __sb.Append(Success);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class read_args : TBase
    {
      private int _id;

      public int Id
      {
        get
        {
          return _id;
        }
        set
        {
          __isset.id = true;
          this._id = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool id;
      }

      public read_args() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              case 1:
                if (field.Type == TType.I32) {
                  Id = iprot.ReadI32();
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("read_args");
          oprot.WriteStructBegin(struc);
          TField field = new TField();
          if (__isset.id) {
            field.Name = "id";
            field.Type = TType.I32;
            field.ID = 1;
            oprot.WriteFieldBegin(field);
            oprot.WriteI32(Id);
            oprot.WriteFieldEnd();
          }
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("read_args(");
        bool __first = true;
        if (__isset.id) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Id: ");
          __sb.Append(Id);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class read_result : TBase
    {
      private string _success;

      public string Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public read_result() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              case 0:
                if (field.Type == TType.String) {
                  Success = iprot.ReadString();
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("read_result");
          oprot.WriteStructBegin(struc);
          TField field = new TField();

          if (this.__isset.success) {
            if (Success != null) {
              field.Name = "Success";
              field.Type = TType.String;
              field.ID = 0;
              oprot.WriteFieldBegin(field);
              oprot.WriteString(Success);
              oprot.WriteFieldEnd();
            }
          }
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("read_result(");
        bool __first = true;
        if (Success != null && __isset.success) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Success: ");
          __sb.Append(Success);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class write_args : TBase
    {
      private int _id;
      private string _value;

      public int Id
      {
        get
        {
          return _id;
        }
        set
        {
          __isset.id = true;
          this._id = value;
        }
      }

      public string Value
      {
        get
        {
          return _value;
        }
        set
        {
          __isset.@value = true;
          this._value = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool id;
        public bool @value;
      }

      public write_args() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              case 1:
                if (field.Type == TType.I32) {
                  Id = iprot.ReadI32();
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              case 2:
                if (field.Type == TType.String) {
                  Value = iprot.ReadString();
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("write_args");
          oprot.WriteStructBegin(struc);
          TField field = new TField();
          if (__isset.id) {
            field.Name = "id";
            field.Type = TType.I32;
            field.ID = 1;
            oprot.WriteFieldBegin(field);
            oprot.WriteI32(Id);
            oprot.WriteFieldEnd();
          }
          if (Value != null && __isset.@value) {
            field.Name = "value";
            field.Type = TType.String;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteString(Value);
            oprot.WriteFieldEnd();
          }
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("write_args(");
        bool __first = true;
        if (__isset.id) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Id: ");
          __sb.Append(Id);
        }
        if (Value != null && __isset.@value) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Value: ");
          __sb.Append(Value);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class write_result : TBase
    {
      private bool _success;

      public bool Success
      {
        get
        {
          return _success;
        }
        set
        {
          __isset.success = true;
          this._success = value;
        }
      }


      public Isset __isset;
      #if !SILVERLIGHT
      [Serializable]
      #endif
      public struct Isset {
        public bool success;
      }

      public write_result() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              case 0:
                if (field.Type == TType.Bool) {
                  Success = iprot.ReadBool();
                } else { 
                  TProtocolUtil.Skip(iprot, field.Type);
                }
                break;
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("write_result");
          oprot.WriteStructBegin(struc);
          TField field = new TField();

          if (this.__isset.success) {
            field.Name = "Success";
            field.Type = TType.Bool;
            field.ID = 0;
            oprot.WriteFieldBegin(field);
            oprot.WriteBool(Success);
            oprot.WriteFieldEnd();
          }
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("write_result(");
        bool __first = true;
        if (__isset.success) {
          if(!__first) { __sb.Append(", "); }
          __first = false;
          __sb.Append("Success: ");
          __sb.Append(Success);
        }
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class close_args : TBase
    {

      public close_args() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("close_args");
          oprot.WriteStructBegin(struc);
          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("close_args(");
        __sb.Append(")");
        return __sb.ToString();
      }

    }


    #if !SILVERLIGHT
    [Serializable]
    #endif
    public partial class close_result : TBase
    {

      public close_result() {
      }

      public void Read (TProtocol iprot)
      {
        iprot.IncrementRecursionDepth();
        try
        {
          TField field;
          iprot.ReadStructBegin();
          while (true)
          {
            field = iprot.ReadFieldBegin();
            if (field.Type == TType.Stop) { 
              break;
            }
            switch (field.ID)
            {
              default: 
                TProtocolUtil.Skip(iprot, field.Type);
                break;
            }
            iprot.ReadFieldEnd();
          }
          iprot.ReadStructEnd();
        }
        finally
        {
          iprot.DecrementRecursionDepth();
        }
      }

      public void Write(TProtocol oprot) {
        oprot.IncrementRecursionDepth();
        try
        {
          TStruct struc = new TStruct("close_result");
          oprot.WriteStructBegin(struc);

          oprot.WriteFieldStop();
          oprot.WriteStructEnd();
        }
        finally
        {
          oprot.DecrementRecursionDepth();
        }
      }

      public override string ToString() {
        StringBuilder __sb = new StringBuilder("close_result(");
        __sb.Append(")");
        return __sb.ToString();
      }

    }

  }
}