var Db = require('./dboperations');
var People = require('./people');
const dboperations = require('./dboperations');

var express = require('express');
var bodyParser = require('body-parser');
var cors = require('cors');
var app = express();
var router = express.Router();

app.use(bodyParser.urlencoded({ extended: true}));
app.use(bodyParser.json());
app.use(cors());
app.use('/LogbookBE', router);

// Middleware - always called first before executing others
// Recommended to perform authentication, 
// authorization and verification 
router.use((request,response,next)=>{
	console.log('middleware');
	next();
})

// Get People 
router.route('/people').get((request, response)=>{
	dboperations.getPeople().then(result =>{
		response.json(result[0]);
	})
})

// Get Records 
router.route('/records').get((request, response)=>{
	dboperations.getRecords().then(result =>{
		response.json(result[0]);
	})
})

// Add record
router.route('/addrecord').post((request, response)=>{
		let record = {...request.body}
		dboperations.InsertRecord(record).then(result =>{
		response.status(201).json(result);
	})
})

app.get('/',(request, response ) =>{
	response.json('hi');
})

app.get('/records',(request, response)=>{
	dboperations.getRecords().then(result =>{
		response.json(result[0]);
	})
})

var port = process.env.PORT || 8000; 
app.listen(port);
console.log('Logbook API is running at ' + port);

// Testing to get data from database
// dboperations.getRecords().then(result =>{
// 	console.log(result);
// })