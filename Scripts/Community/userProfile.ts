const sendChatBtn = <HTMLButtonElement>document.querySelector(".chatSendBtn");

async function sendChat(userId: string): Promise<void> {
    const textInput = <HTMLTextAreaElement>document.querySelector(".messageAreaInput");

    if (textInput.value.length < 5) {
        alert("Your message must be at least 5 characters long.");
        return;
    }

    const sendMessage = {
        OtherId: userId,
        Content: textInput.value
    }

    const response = await fetch("/SendPrivateMessage", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(sendMessage)
    });

    if (response.ok) {
        alert("Your message was sent!");
    } else {
        alert("Something went wrong");
    }
}



sendChatBtn.addEventListener("click", () => {
    const userId = sendChatBtn.getAttribute("id")?.split("-")[1];

    if (!userId) return;

    sendChat(userId);
})