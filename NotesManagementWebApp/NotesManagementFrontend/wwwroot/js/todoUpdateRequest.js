import { getAllNotes } from "./getNotesRequest.js";

$("#notesContainer").on("click",".todoUpdateBtn", function () {
    let noteToBeUpdated = $(this).val();
    $.ajax({
        url: "https://localhost:44337/api/updateTodoStatus",
        type: "POST",
        headers: {
            contentType: "application/json",
            Authorization: $("#authorizeToken").val()
        },
        data: {
            noteToBeUpdated
        },
        success: () => {
            //get all notes after updating todo
            getAllNotes();

            //notify todo update 
            var showMessage = document.getElementById("msg");
            showMessage.innerHTML = "Marked as completed.";
            var toast = new bootstrap.Toast(document.getElementById('liveToast'));
            toast.show();
        },
        error: (err) => {
            alert(err);
            console.log(err);
        }
    })
})