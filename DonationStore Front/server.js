const express = require('express');
const path = require('path');
const app = express()

const PORT = process.env.PORT || 8080;

app.use(express.static(__dirname + '/dist/donationstore'));

app.get('/*',(req,res) => {
  res.sendFile(__dirname + '/dist/donationstore/index.html');
});

app.listen(PORT, () =>{
  console.log('asdsadas' + PORT)
})
