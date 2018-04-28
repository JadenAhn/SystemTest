/* util.js
* Assignment 4
*
*   Revision History
*       Jaden Ahn, 2018.04.06 : Created
*/
function doValidate_frmRegister() {
    var form = $("#frmRegister");

    form.validate({
        rules: {
            txtName: {
                required: true
            },
            txtAddress: {
                required: true
            },
            txtCity: {
                required: true
            },
            txtPhone: {
                required: true,
                phonecheck: true
            },
            txtEmail: {
                required: true
            },
            txtMake: {
                required: true
            },
            txtModel: {
                required: true
            },
            txtYear: {
                required: true,
                lengthcheck: true
            }
        },
        messages: {
            txtName: {
                required: "Seller Name required"
            },
            txtAddress: {
                required: "Address required"
            },
            txtCity: {
                required: "City required"
            },
            txtPhone: {
                required: "Phone required",
                phonecheck: "Wrong format"
            },
            txtEmail: {
                required: "Email required"
            },
            txtMake: {
                required: "Car Make required"
            },
            txtModel: {
                required: "Car Model required"
            },
            txtYear: {
                required: "Car Year required",
                lengthcheck: "Enter 4 digit number"
            }
        }
    });

    return form.valid();
}

jQuery.validator.addMethod("lengthcheck",
    function (value, element) {
        if(value.length != 4)
        {
            return false;
        }
        return true;
    },
    "Enter 4 digit number");

jQuery.validator.addMethod("phonecheck",
    function (value, element) {
        var regex = /\d{3}-\d{3}-\d{4}|[(]\d{3}[)]\d{3}-\d{4}/;
        return this.optional(element) || regex.test(value);
    },
    "Wrong format");