"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (message) {
    addMessage(message);
});

function addMessage(msg) {

    let text = msg.messageText;
    let date = (new Date(msg.date)).toLocaleDateString() + " " + (new Date(msg.date)).toLocaleTimeString();
    let summaryText = text.replace(/<.*?>/, " ");
    if (summaryText.length > 200) {
        summaryText = summaryText.substring(0, 197) + "...";
    }

    let user_chat = document.getElementById("user" + msg.fromUser.userName.toLocaleLowerCase());
    if (user_chat !== null) {
        user_chat.getElementsByClassName("chat_date")[0].innerHTML = date;
        user_chat.getElementsByClassName("chat_text")[0].innerHTML = summaryText;

        if (user_chat.classList.contains("active_chat")) {
            var htmlMsg = "<div class=\"outgoing_msg\">" +
                "<div class=\"incoming_msg_img\" >" +
                "<img src=\"https://ptetutorials.com/images/user-profile.png\">" +
                "</div>" +
                "<div class=\"received_msg\">" +
                "<div class=\"received_withd_msg\">" +
                "<div>" + text + "</div>" +
                "<span class=\"time_date\">" + date + "</span>" +
                "</div></div></div>";
            var chat = document.getElementsByClassName("msg_history")[0];
            chat.insertAdjacentHTML('beforeend', htmlMsg);
            chat.scrollTop = chat.scrollHeight;
        }
    }
    else {
        let elChat = "<div onclick=\"changeChat(this)\" id=\"user" + msg.fromUser.userName.toLocaleLowerCase() +
            "\" class=\"chat_list\"><div class=\"chat_people\"><div class=\"chat_img\">" +
            "<img src=\"https://ptetutorials.com/images/user-profile.png\" alt=\"sunil\"></div><div class=\"chat_ib\">" +
            "<h5>" + msg.fromUser.userName + "<span class=\"chat_date\">" + date + "</span></h5>" +
            "<p class=\"chat_text\">" + summaryText + "</p></div></div></div>";

        let chats = document.getElementsByClassName("inbox_chat")[0];
        chats.insertAdjacentHTML("afterbegin", elChat);
    }
}

function findOrCreateActiveChat() {
    var activeUser = window.location.hash.slice(1);
    if (activeUser.length > 0) {
        if (document.getElementById("user" + activeUser.toLocaleLowerCase()) !== null) {
            document.getElementById("user" + activeUser.toLocaleLowerCase()).classList.add("active_chat");
            return activeUser;
        }

        connection.invoke("UserIsExist", activeUser).then(function (res) {
            if (!res) window.location.href = window.location.pathname;

            let elChat = "<div id=\"user" + activeUser.toLocaleLowerCase() +
                "\" class=\"chat_list active_chat\"><div class=\"chat_people\"><div class=\"chat_img\">" +
                "<img src=\"https://ptetutorials.com/images/user-profile.png\" alt=\"sunil\"></div><div class=\"chat_ib\">" +
                "<h5>" + activeUser + "<span class=\"chat_date\"></span></h5>" +
                "<p class=\"chat_text\">empty!</p></div></div></div>";


            let chats = document.getElementsByClassName("inbox_chat")[0];
            chats.insertAdjacentHTML("afterbegin", elChat);
            return activeUser;
        });
    }
    else if (document.getElementsByClassName("chat_list").length > 0) {
        activeUser = document.getElementsByClassName("chat_list")[0].id.slice(4);
        if (activeUser.length > 0) {
            document.getElementById("user" + activeUser).classList.add("active_chat");
            return activeUser;
        }
    }
    return null;
}

function loadMsgs() {
    var activeUser = findOrCreateActiveChat();

    if (activeUser !== null) {
        connection.invoke("GetAllChatByUser", activeUser).then(function (msgs) {
            msgs.forEach(function (msg) {
                var htmlMsg = "";
                if (msg.toUser.userName.toLocaleLowerCase() === activeUser) {
                    htmlMsg = "<div class=\"outgoing_msg\">" +
                        "<div class=\"sent_msg\">" +
                        "<div>" + msg.messageText + "</div>" +
                        "<span class=\"time_date\">" + msg.date + "</span>" +
                        "</div></div>";
                }
                else {
                    htmlMsg = "<div class=\"outgoing_msg\">" +
                        "<div class=\"incoming_msg_img\" >" +
                        "<img src=\"https://ptetutorials.com/images/user-profile.png\">" +
                        "</div>" +
                        "<div class=\"received_msg\">" +
                        "<div class=\"received_withd_msg\">" +
                        "<div>" + msg.messageText + "</div>" +
                        "<span class=\"time_date\">" + msg.date + "</span>" +
                        "</div></div></div>";
                }
                var chat = document.getElementsByClassName("msg_history")[0];
                chat.insertAdjacentHTML('beforeend', htmlMsg);
                chat.scrollTop = chat.scrollHeight;
            });
        });
    }
}

sendMessage.addEventListener("click", function () {
    if (txtMessage.value.length > 0) {
        if (document.getElementsByClassName("active_chat").length > 0) {

            var activeChat = document.getElementsByClassName("active_chat")[0];
            var user = activeChat.id.slice(4);
            if (user.length > 0) {
                connection.invoke("SendMessage", txtMessage.value, user).then(function (msg) {

                    let text = msg.messageText;
                    let date = (new Date(msg.date)).toLocaleDateString() + " " + (new Date(msg.date)).toLocaleTimeString();
                    let summaryText = text.replace(/<.*?>/, " ");
                    if (summaryText.length > 200) {
                        summaryText = summaryText.substring(0, 197) + "...";
                    }

                    var htmlMsg = "<div class=\"outgoing_msg\">" +
                        "<div class=\"sent_msg\">" +
                        "<div>" + text + "</div>" +
                        "<span class=\"time_date\">" + date + "</span>" +
                        "</div></div>";

                    var msgHistory = document.getElementsByClassName("msg_history")[0];
                    msgHistory.insertAdjacentHTML('beforeend', htmlMsg);
                    msgHistory.scrollTop = msgHistory.scrollHeight;

                    activeChat.getElementsByClassName("chat_text")[0].innerHTML = summaryText;
                    activeChat.getElementsByClassName("chat_date")[0].innerHTML = date;

                    txtMessage.value = "";
                });
            }
        }
    }
});

function changeChat(el) {
    window.location.hash = "#" + el.id.slice(4);
    if (document.getElementsByClassName("active_chat").length > 0)
        document.getElementsByClassName("active_chat")[0].classList.remove("active_chat");
    document.getElementsByClassName("msg_history")[0].innerHTML = "";
    loadMsgs();
}

window.onload = function () {

    connection.start().then(function () {

        loadMsgs();

    }).catch(function (err) {
        console.error(err.toString());
    });
    
};