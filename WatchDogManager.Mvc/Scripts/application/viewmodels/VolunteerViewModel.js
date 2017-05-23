var VolunteerViewModel = function (baseUrl, detailDialog) {
    var self = this;

    self.errorMessage = ko.observable("");
    self.errorMessageVisible = ko.computed(function () { return self.errorMessage().length > 0 });
    self.volunteers = ko.observableArray();

    self.isNewUser = false;
    self.selectedUser = null;
    self.selectedUserName = ko.observable();
    self.selectedUserEmail = ko.observable();
    self.selectedUserPhone = ko.observable();
    self.selectedUserBackgroundCheck = ko.observable();
    self.selectedUserStudents = ko.observable();
    self.selectedUserTeachers = ko.observable();

    self.showDetail = function (item) {
        self.isNewUser = false;
        self.selectedUser = item;

        self.selectedUserName(item.Name);
        self.selectedUserEmail(item.Email);
        self.selectedUserPhone(item.Phone);
        self.selectedUserBackgroundCheck(item.BackgroundCheck);
        self.selectedUserStudents(item.Students);
        self.selectedUserTeachers(item.Teachers);

        detailDialog.modal("show");
    };

    self.deleteSelected = function () {
        var deleteUrl = baseUrl + '/' + self.selectedUser.Id;

        $.ajax({
            type: "DELETE",
            url: deleteUrl,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                self.getVolunteers();
            },
            error: function (response) {
                self.errorMessage(response);
            }
        });
    };

    self.saveChanges = function () {
        if (self.isNewUser) {
            var createUrl = baseUrl;

            var createItem = {};
            createItem.Name = self.selectedUserName();
            createItem.Email = self.selectedUserEmail();
            createItem.Phone = self.selectedUserPhone();
            createItem.BackgroundCheck = self.selectedUserBackgroundCheck();
            createItem.Students = self.selectedUserStudents();
            createItem.Teachers = self.selectedUserTeachers();

            $.ajax({
                type: "POST",
                url: createUrl,
                data: JSON.stringify(createItem),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    self.getVolunteers();
                },
                error: function (response) {
                    self.errorMessage(response);
                }
            });

        } else {
            var updateUrl = baseUrl;

            var updateItem = self.selectedUser;
            updateItem.Name = self.selectedUserName();
            updateItem.Email = self.selectedUserEmail();
            updateItem.Phone = self.selectedUserPhone();
            updateItem.BackgroundCheck = self.selectedUserBackgroundCheck();
            updateItem.Students = self.selectedUserStudents();
            updateItem.Teachers = self.selectedUserTeachers();

            $.ajax({
                type: "PUT",
                url: updateUrl,
                data: JSON.stringify(updateItem),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    self.getVolunteers();
                },
                error: function (response) {
                    self.errorMessage(response.responseText);
                }
            });
        }
    };

    self.showNew = function () {
        self.isNewUser = true;

        self.selectedUserName("");
        self.selectedUserEmail("");
        self.selectedUserPhone("");
        self.selectedUserBackgroundCheck("");
        self.selectedUserStudents("");
        self.selectedUserTeachers("");

        detailDialog.modal("show");
    };


    self.getVolunteers = function () {
        var getAllUrl = baseUrl;

        $.ajax({
            type: "GET",
            url: getAllUrl,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                self.volunteers(response);
            },
            error: function (response) {
                self.errorMessage(response);
            }
        });
    };
}