        const connection = new signalR.HubConnectionBuilder()
            .withUrl("/chatHub")
            .build();

        connection.start()
        let btn = document.getElementById("sendBtn")
        let USER = document.getElementById("user")
        let message = document.getElementById("message")
        btn.addEventListener("click", () => {
            connection.invoke("SendMessageAsync",user.value, message.value);
        })

          connection.on("usersMessage", (user,message) => {
         

            var li = document.createElement("li");
            document.getElementById("messagesList").appendChild(li);
            li.textContent = `${user} : ${message}`;
        })
     
