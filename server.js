'use strict';
const express = require("express");

const app = express();
const port = process.env.PORT || "8000";

app.get("/", (req, res) => {
    res.status(200).send("Hello from Express");
});

app.listen(port, () => {
    console.log(`Listening to requests on http://localhost:${port}`);
});
