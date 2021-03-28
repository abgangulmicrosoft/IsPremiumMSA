'use strict';
const express = require('express');
var port = process.env.PORT || 1337;

const app = express();

app.get("/", (req, res) => {
    res.status(200).send("Hello from Express");
});

app.listen(port, () => {
    console.log(`Listening to requests on http://localhost:${port}`);
});
