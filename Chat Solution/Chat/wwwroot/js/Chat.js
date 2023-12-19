
document.addEventListener('DOMContentLoaded', function () {
    var userName = prompt("Plz Enter Your Name: ");

    var massageInput = document.getElementById("massageInp");
    

    massageInput.focus();
    

    var proxyConnection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();

    proxyConnection.start().then(function () {
        document.getElementById("sendMassageBtn").addEventListener("click", function (e) {
            e.preventDefault();
            proxyConnection.invoke("Send", userName, massageInput.value);
        });
    }).catch(function (error) {
        console.log(error);
    });

    proxyConnection.on("ReceiveMessage", function (userName, massage) {
        var listElement = document.createElement('li');
        listElement.innerHTML = `<strong>${userName} : </strong> ${massage}`;
        document.getElementById("conversation").appendChild(listElement);
    })
})