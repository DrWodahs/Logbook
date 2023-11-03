CREATE PROCEDURE [dbo].[AddRecord]
	@inputPeopleNric VARCHAR(20),
	@inputPeopleName VARCHAR(300),
	@inputReason VARCHAR(300),
	@inputSignInDate VARCHAR(10),
	@inputSignInTime VARCHAR(8)
AS
BEGIN
	-- Declare variables to insert into Records
	DECLARE @newPeopleID AS INT;
	DECLARE @newSignInID AS INT;
	DECLARE @newRecordID AS INT;

	--Create New Entry in People
	--Check if NRIC exist
	Select @newPeopleID = PK_PeopleID from People WHERE PeopleNric = @inputPeopleNric;
	Insert INTO People(PK_PeopleID, PeopleNric, PeopleName) VALUES (@newPeopleID, @inputPeopleNric, @inputPeopleName);
	
	--Create New Entry in Sign In 
	SELECT @newSignInID = COUNT(PK_SignInID) + 1 from SignIn;
	Insert INTO SignIn(PK_SignInID, SignInDate, SignInTime) VALUES (@newSignInID, @inputSignInDate, @inputSignInTime);

	--Create New Entry in Records
	SELECT @newRecordID = COUNT(PK_RecordID) + 1 from Records;
	Insert INTO Records(PK_RecordID, FK_PeopleID, FK_SignInID, FK_SignOutID, Reason) 
	VALUES (@newRecordID, @newPeopleID, @newSignInID, NULL, @inputReason);
END