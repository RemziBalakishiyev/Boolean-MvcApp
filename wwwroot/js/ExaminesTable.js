$(document).ready(function () {
    loadExamineTable();
})

function loadExamineTable() {
    $("#examineTable").dataTable({
        ajax: {
            url: "/Exam/GetExamines",
            dataSrc: ""
        },
        columns: [
            { data: 'id' },
            {
                data: 'fullName',
                render: function (data, type, row) {
                    return `${row.student.firstName} ${row.student.lastName }`;
                }

            },

            {
                data: 'subject',
                render: function (data, type, row) {
                    return `${row.subject.name}`;
                }
            },
            { data: 'result' },
        ]
    })



}