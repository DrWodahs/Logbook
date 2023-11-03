const config = {
	user : 'user',
	password : "login",
	server: "127.0.0.1",
	database: "LogbookDB",
	options:{
		trustedConnection: true,
		enableArithAbort : true,
		instancename : 'SQLSERVER'
	},
	port : 1433
}

module.exports = config;
