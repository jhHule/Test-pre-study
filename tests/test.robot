*** Settings ***


*** Test Cases ***
My Test case
	Tee jotain
	Run Keyword And Expect Error	1 != 2	Tama failaa

My another Test case
	Run Keyword And Expect Error	1 != 2	Tama failaa
	
	
*** Keywords ***
Tee jotain
	Log	Log message
	
Tama failaa
	Should Be Equal	1	2