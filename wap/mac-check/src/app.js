const csv = require('fast-csv');
const sha256 = require('simple-sha256')
const xml = require('object-to-xml');
const fs = require('fs');
const path = require('path');
const { response, json } = require('express');
const express = require('express');
const e = require('express');
const app = express();
const port = 80;
const secret = "123456";

let ready = false;
app.use(express.static('public'));


function loadOrg(filename, options) {
    console.log("Loading records....");
    let orgdata = {};
    fs.createReadStream(path.resolve(__dirname, filename))
    .pipe(csv.parse(options))
    .on('error', error => console.error(error))
    .on('data', row => {orgdata[`${row[0]}`] = row[1]})
    .on('end', rowCount => {console.log(`Loaded ${rowCount} records`); ready = true });
    return orgdata;
}

function error(ans, req, res) {
    if (req.query.format == "xml"){
        res.set('Content-Type', 'text/xml');
        res.send(xml({ xml: ans}));
    } else if (req.query.format == "csv") {
        res.send(ans.error);
    } else {
        res.json(ans);
    }
}

app.get('/api/range/:mac', (req, res) => {

    // console.log(req);
    allowed = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"];
    mac = req.params.mac.toUpperCase();
    newmac = "";

    if(mac.length < 6) {
        res.status(400);
        ans = { error: 'Mac address too short', code: 400 };
        error(ans, req, res);
        return;
    }
    
    for (var i = 0; i < 6; i++) {
        if (allowed.includes(mac.charAt(i))) {
            newmac = newmac + mac.charAt(i);
        } else {
            res.status(400);
            ans = { error: 'Invalid mac', code: 400 };
            error(ans, req, res);
            return;
        }
    }

    while(!ready) {};

    if(orgdata[mac] !== undefined) {

        result = {"range":mac,"organization":orgdata[mac]};
        console.log(JSON.stringify(result));
        const resulthash = sha256.sync(result+secret);
        if (req.query.format == "xml"){
            res.set('Content-Type', 'text/xml');
            res.send(xml({xml: {result: result, code:200, hash:resulthash}},));
        } else if (req.query.format == "csv") {
            res.set('Content-Type', 'text/csv');
            res.send(result.mac+","+result.organization);
        } else {
            res.json({result: result, code:200, hash:resulthash});
        }
    } else {
        res.status(404);
        ans = {error:"Range not found", code: 404};
        error(ans, req, res);
        return;
    }
})

app.use(function (req, res, next) {
    res.status(404);
    console.log(req.query);
    ans = { error: 'Not found', code: 404 }
    if (req.query.format == "xml"){
        res.set('Content-Type', 'text/xml');
        res.send(xml({xml: ans}));
    } else if (req.query.format == "csv") {
        res.send(ans.error);
    } else if (req.query.format == "json") {
        res.json(ans);
    }

    // respond with html page
    if (req.accepts('html') && !req.url.startsWith("/api")) {
        res.send('<h1>Page not found</h1>');
        return;
    }

    // respond with json
    if (req.accepts('json')) {
        res.json({ error: 'Not found', code: 404 });
        return;
    }

    // default to plain-text. send()
    res.send('404');
});

const orgdata = loadOrg("oui-fix.csv");

app.listen(port, () => {
    console.log(`App listening on port ${port}`);
})
