var connectionchat = new signalR.HubConnectionBuilder()
    .withUrl("/hubs/firstChat").build();

document.getElementById("sendMessage").disabled = true;
connectionchat.on("MessageRecieved", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user} - ${message}`;
});

document.getElementById("sendMessage").addEventListener("click", function (event) {
    var sender = document.getElementById("senderEmail").value;
    var message = document.getElementById("chatMessage").value;
    var reciever = document.getElementById("receiverEmail").value;
    if (receiver.length > 0) {
        connectionChat.send("SendMessageToReceiver", sender, receiver, message);
    }
    else {
        //send message to all of the users
        connectionChat.send("SendMessageToAll", sender, message).catch(function (err) {
            return console.error(err.toString());
        });
    }

    //send message to all user
    connectionchat.send("SendMessageToAll", user, message).catch(function (err) {
        return console.error(err.toString());
    });;

    event.preventDefault();
})

connectionchat.start().then(function () {
    document.getElementById("sendMessage").disabled = false;
});
