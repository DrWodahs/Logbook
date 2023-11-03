var config = require('./dbconfig');
const sql = require('mssql');

async function getPeople(){
	try {
		let pool = await sql.connect(config);
		let peopleset = await pool.request().query("SELECT * from People");
		return peopleset.recordsets;
	}
	catch (error){
		console.log(error);
	}
}

async function getRecords(){
	try {
		let querytxt = "SELECT r.PK_RecordID, p.PeopleNric, p.PeopleName, " +
					   "r.Reason, si.SignInDate, si.SignInTime, so.SignOutDate, so.SignOutTime " +
					   "FROM RECORDS as r INNER JOIN PEOPLE as p on r.FK_PeopleID = p.PK_PeopleID " +
					   "INNER JOIN SignIn as si on r.FK_SignInID = si.PK_SignInID " +
					   "LEFT JOIN SignOut as so on r.FK_SignOutID = so.PK_SignOutID;"
		let pool = await sql.connect(config);
		let records = await pool.request().query(querytxt);
		return records.recordsets;
	}
	catch (error){
		console.log(error);
	}
}

async function InsertRecord(Record){
	try {
		let pool = await sql.connect(config);
		let insertedRecord = await pool.request().
			input('NRIC', sql.VarChar(20), Record.Nric).
			input('Name', sql.VarChar(300), Record.Name).
			input('Reason', sql.VarChar(300), Record.Reason).
			input('Date', sql.VarChar(10), Record.SignInDate).
			input('Time', sql.VarChar(10), Record.SignInTime).
			execute('AddRecord');
		return insertedRecord.recordsets;
	}
	catch (error){
		console.log(error);
	}
}

module.exports = {
	getPeople : getPeople,
	getRecords : getRecords,
	InsertRecord : InsertRecord
}
