var Employee = function () {
    var EmployeeModel = {

        id: ko.observable(),
        name: ko.observable(),
        contractTypeName: ko.observable(),
        roleId: ko.observable(),
        roleName: ko.observable(),
        roleDescription: ko.observable(),
        hourlySalary: ko.observable(),
        monthlySalary: ko.observable(),
        annualSalary: ko.observable(),
        idSearch: ko.observable(),

    };
    return EmployeeModel;
};
var URL = koUrlApi + 'Employee';

koModel.listEmployees = ko.observableArray([]);
koModel.vEmployee = ko.observable();

function findEmployee() {
    if ((koModel.vEmployee().idSearch() != undefined) && (koModel.vEmployee().idSearch() != '') && (koModel.vEmployee().idSearch() > 0)) {
        GetEmployeeById(koModel.vEmployee().idSearch());
    } else {
        getListEmployees();
    }
}

function GetEmployeeById(idEmployee) {
    
    $.ajax({
        url: URL + '?id=' + idEmployee,
        type: "GET",        
        async: false,
        contentType: 'application/json',
        success: function (data) {
            
            koModel.listEmployees.removeAll();

            koModel.listEmployees.push(data);
        },
        error: function (error) {

            try {
                alert('error; ' + eval(error.responseText));
            } catch (err) {
                alert('error; ' + (error.responseText));
            }

        }
    });
    return null;
}


function getListEmployees() {
    
    $.ajax({
        url: URL,
        type: "GET",
        headers: { "Access-Control-Allow-Origin": URL },
        async: false,
        crossDomain: true,
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            
            koModel.listEmployees.removeAll();

            for (var i = 0; i < data.length; i++) {
                var aux = reflectionObject(data[i], new Employee());

                koModel.listEmployees.push(aux);
            }
        },
        error: function (error) {

            try {
                alert('error; ' + eval(error.responseText));
            } catch (err) {
                alert('error; ' + (error.responseText));
            }

        }
    });
}