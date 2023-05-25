Feature: Amazon

@smoke
Scenario: Search For Today's Deal
	Given user navigetes to amazon 
	When user cliks on the Todays Deal 
	Then user sees Todays Deal Text
     Then Verify options are present
	| Options                  |
	| Prime Early Access deals |
	| Prime Exclusive deals    |