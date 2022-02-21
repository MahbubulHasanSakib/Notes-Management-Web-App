
import { getAllNotes } from './getNotesRequest.js'

document.onload = getAllNotes();

var myNotes = document.getElementsByClassName("myNote")
for (var i = 0; i < myNotes.length; i++) {
    myNotes[i].addEventListener("submit", (event) => {
        event.preventDefault();
        var notesData;
        //get all data from the form
        const formData = new FormData(event.target); 
        switch (formData.get("type")) {
            case "Regular": {
                notesData = {
                    title: formData.get("title"),
                    text: formData.get("text"),
                    type: formData.get("type")
                };
                break;
            }
            case "Reminder": {
                notesData = {
                    
                    title: formData.get("title"),
                    text: formData.get("text"),
                    datetime: formData.get("datetime"),
                    type: formData.get("type")
                };
                break;
            }
            case "Todo": {
                notesData = {
                    
                    title: formData.get("title"),
                    text: formData.get("text"),
                    dueDateTime: formData.get("dueDateTime"),
                    type: formData.get("type")
                };
                break;
            }
            case "Bookmark": {
                notesData = {
                    title: formData.get("title"),
                    noteUrl: formData.get("noteUrl"),
                    type: formData.get("type")
                };
                break;
            }
        }

        
        if (notesData) {
            //validate note text for not more than 100 characters
            if (notesData.text) {
                if (notesData.text.length > 100) {
                    alert("Note text should be maximum 100 characters");

                    return;
                }
            }

          //post data to server
            $.ajax({
                url: "https://localhost:44337/api/addNewNote",
                type: "POST",
                headers: {
                    contentType: "application/json",
                    Authorization: $("#authorizeToken").val()
                },
                data:notesData,
                success: () => {
                    getAllNotes();
                    document.getElementById("msg").innerHTML = "Saved Successfully.";
                    var toast = new bootstrap.Toast(document.getElementById('liveToast'));
                    toast.show();
                },
                error: (err) => {
                    alert(err.responseText);
                }
            })
        }
    })
}





