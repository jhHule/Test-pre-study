*** Settings ***
Library	StorageLibrary.py


*** Test Cases ***
My Test case
	write storage point value	0	12
	${V1}=	read storage point value	0
	Should be equal	${V1}	12
	Tama failaa

My another Test case
	Run Keyword And Expect Error	Tama failaa
	
	
*** Keywords ***
Tee jotain
	Log	Log message
	
Tama failaa
	Should Be Equal	1	2