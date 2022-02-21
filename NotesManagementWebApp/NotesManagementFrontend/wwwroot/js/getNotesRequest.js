export function getAllNotes() {
    $.ajax({
        url: "https://localhost:44337/api/getAllNotes",
        type: "GET",
        headers: {
            contentType: "application/json",
            Authorization: $("#authorizeToken").val()
        },
        success: (data) => {
            showAllNotes(data);
        },
        error: (err) => {
            alert(err);
        }
    })

}

export function showAllNotes(data) {
    $("#notesContainer").empty();
    let allNotes = JSON.parse(data);
    for (var i = allNotes.length - 1; i >= 0; i--) {
        var newNote;
        switch (allNotes[i].Type) {
            case "Regular":

                newNote = `<div class="card">
  <div class="card-header">
  <b>Title: ${allNotes[i].Title}</b>
  </div>
  <div class="card-body">
    <span><b>Text:</b>${allNotes[i].Text}</span><br/>
 <span><b>Created At:</b> ${allNotes[i].CreatedAt}</span><br/>
     <span><b>Type:</b> ${allNotes[i].Type}</span>
  </div>
</div><br/>`;
                break;
            case "Reminder":
                newNote = `<div class="card">
  <div class="card-header">
  <b>Title: ${allNotes[i].Title}</b>
  </div>
  <div class="card-body">
    <span><b>Text:</b>${allNotes[i].Text}</span><br/>
 <span><b>Created At:</b> ${allNotes[i].CreatedAt}</span><br/>
 <span><b>Reminder date :</b>${allNotes[i].DateTime}</span><br/>
<span><b>Type:</b>${allNotes[i].Type}</span><br/>
  </div>
</div><br/>`;
                break;
            case "Todo":
                newNote = `<div class="card">
  <div class="card-header">
  <b>Title: ${allNotes[i].Title}</b>
  </div>
  <div class="card-body">
    <span><b>Text:</b>${allNotes[i].Text}</span><br/>
 <span><b>Created At:</b> ${allNotes[i].CreatedAt}</span><br/>
<span><b>Task Due  : </b>${allNotes[i].DueDate}</span><br/>
<span><b>Task Completed : </b>${allNotes[i].IsCompleted==='true'?'YES':'NO'}</b></span><br/>
<span><b>Type: </b>${allNotes[i].Type}</span><br/>
 <button value="${allNotes[i].NoteId}" class="${allNotes[i].IsCompleted === 'true' ? 'disabled' : ''} btn btn-sm todoUpdateBtn btn-success ">Turn as done</button>
  </div>
</div><br/>`;
                break;
            default:

                newNote = `<div class="card">
  <div class="card-header">
  <b>Title: ${allNotes[i].Title}</b>
  </div>
  <div class="card-body">
 <span><b>URL:</b></span>
<a href="${allNotes[i].NoteUrl}">${allNotes[i].NoteUrl}</a><br/>
 <span><b>Created At :</b>${allNotes[i].CreatedAt}</span><br/>
<span><b>Type:</b>${allNotes[i].Type}</span><br/>
  </div>
</div><br/>`;

        }

        //append the created note under noteContainer div
        $("#notesContainer").append(newNote);
    }
}