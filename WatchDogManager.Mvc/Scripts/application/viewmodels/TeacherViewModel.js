var TeacherViewModel = function (baseUrl, detailDialog) {
    var self = this;

    self.errorMessage = ko.observable("");
    self.errorMessageVisible = ko.pureComputed(function () { return self.errorMessage().length > 0 });
    self.teachers = ko.observableArray();

    self.isNewTeacher = false;
    self.selectedTeacher = null;
    self.selectedTeacherName = ko.pureComputed(function () { return self.selectedTeacherFirstName() + " " + self.selectedTeacherLastName() });
    self.selectedTeacherFirstName = ko.observable();
    self.selectedTeacherLastName = ko.observable();
    self.selectedTeacherGrade = ko.observable();
    self.selectedTeacherRoomNumber = ko.observable();


    self.showDetail = function (item) {
        self.isNewTeacher = false;
        self.selectedTeacher = item;

        self.selectedTeacherFirstName(item.FirstName);
        self.selectedTeacherLastName(item.LastName);
        self.selectedTeacherGrade(item.Grade);
        self.selectedTeacherRoomNumber(item.RoomNumber);

        detailDialog.modal("show");
    };

    self.deleteSelected = function () {
        var deleteUrl = baseUrl + '/' + self.selectedTeacher.Id;

        $.ajax({
            type: "DELETE",
            url: deleteUrl,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                self.getTeachers();
            },
            error: function (response) {
                self.errorMessage(response);
            }
        });
    };

    self.saveChanges = function () {
        if (self.isNewTeacher) {
            var createUrl = baseUrl;

            var createItem = {};
            createItem.FirstName = self.selectedTeacherFirstName();
            createItem.LastName = self.selectedTeacherLastName();
            createItem.Grade = self.selectedTeacherGrade();
            createItem.RoomNumber = self.selectedTeacherRoomNumber();

            $.ajax({
                type: "POST",
                url: createUrl,
                data: JSON.stringify(createItem),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    self.getTeachers();
                },
                error: function (response) {
                    self.errorMessage(response);
                }
            });

        } else {
            var updateUrl = baseUrl;

            var updateItem = self.selectedTeacher;
            updateItem.FirstName = self.selectedTeacherFirstName();
            updateItem.LastName = self.selectedTeacherLastName();
            updateItem.Grade = self.selectedTeacherGrade();
            updateItem.RoomNumber = self.selectedTeacherRoomNumber();

            $.ajax({
                type: "PUT",
                url: updateUrl,
                data: JSON.stringify(updateItem),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    self.getTeachers();
                },
                error: function (response) {
                    self.errorMessage(response.responseText);
                }
            });
        }
    };

    self.showNew = function () {
        self.isNewTeacher = true;

        self.selectedTeacherFirstName("");
        self.selectedTeacherLastName("");
        self.selectedTeacherGrade("");
        self.selectedTeacherRoomNumber("");

        detailDialog.modal("show");
    };


    self.getTeachers = function () {
        var getAllUrl = baseUrl;

        $.ajax({
            type: "GET",
            url: getAllUrl,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                self.teachers(response);
            },
            error: function (response) {
                self.errorMessage(response);
            }
        });
    };
}