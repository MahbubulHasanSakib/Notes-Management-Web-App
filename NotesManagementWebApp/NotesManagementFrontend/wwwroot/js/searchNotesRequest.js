import { showAllNotes } from "./getNotesRequest.js";

$("#searchNotes").on("change", function () {
    let searchText = this.value;
    if (searchText === "empty") {
        return ;
    }
    $.ajax({
        url: "https://localhost:44337/api/searchNotes",
        type: "POST",
        headers: {
            contentType: "application/json",
            Authorization: $("#authorizeToken").val()
        },
        data: {
            search: searchText
        },
        success: (data) => {
            showAllNotes(data);
        },
        error: (err) => {
            alert(err);
        }
    });
})
