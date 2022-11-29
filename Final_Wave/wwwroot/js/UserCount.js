//create connection 
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/UserCountHub").build();


//connection with hub method
connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("TotalViewsCounter");
    newCountSpan.innerText = value.toString();
});

connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("TotalUsersCounter");
    newCountSpan.innerText = value.toString();
});

//invoke hub method
function NewWindowloadedOnClient() {
    connectionUserCount.send("NewWindowLoaded");
}

//start connection
function fulfilled() {
    console.log("Connection to User Hub successful");
    NewWindowloadedOnClient();
}

function rejected() {

}
connectionUserCount.start().then(fulfilled, rejected);