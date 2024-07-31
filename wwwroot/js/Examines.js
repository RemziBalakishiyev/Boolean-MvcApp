$(document).ready(function () {
    $("#save-exam").click(addNewExam)
})


function addNewExam() {
    let studentId = $("#student-id").val();
    let result = $("#result").val();
    let examDate = $("#exam-date").val();

    const model = {
        studentId: studentId,
        examDate: examDate,
        result:result
    }

    $.ajax({
        type: "POST",
        url: "/Exam/AddExam",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(model),
        success: function () {
            console.log();
        }
    })
}