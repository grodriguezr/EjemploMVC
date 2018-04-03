function NombreVacio() {
    if (document.getElementById('TxtNombre').value == "") {
        return 'El campo de nombre no puede estar vacío';
    }
    else {
        return "";
    }
}

function NombreInvalido() {
    if(document.getElementById('TxtNombre').value.indexOf("@") != -1){
        return 'El nombre no puede contener el caracter @';
    }
    else {
        return "";
    }
}

function ApellidoInvalido() {
    if (document.getElementById('TxtApellido').value.length > 5) {
        return 'El apellido no puede tener más de 5 caracteres'
    }
    else {
        return "";
    }
}

function SalarioVacio() {
    if (document.getElementById('TxtSalario').value == "") {
        return 'El campo de salario no puede estar vacío';
    }
    else {
        return "";
    }
}

function SalarioInvalido() {
    if (isNaN(document.getElementById('TxtSalario').value)) {
        return 'Ingrese un salario válido';
    }
    else {
        return "";
    }
}

function EsValido() {
    var NombreVacioMensaje = NombreVacio();
    var NombreInvalidoMensaje = NombreInvalido();
    var ApellidoInvalidoMensaje = ApellidoInvalido();
    var SalarioVacioMensaje = SalarioVacio();
    var SalarioInvalidoMensaje = SalarioInvalido();
    var MensajeFinalDeError = "Errores:";
    if (NombreVacioMensaje != "") {
        MensajeFinalDeError += "\n" + NombreVacioMensaje;
    }
    if (NombreInvalidoMensaje != "") {
        MensajeFinalDeError += "\n" + NombreInvalidoMensaje;
    }
    if (ApellidoInvalidoMensaje != "") {
        MensajeFinalDeError += "\n" + ApellidoInvalidoMensaje;
    }
    if (SalarioVacioMensaje != "") {
        MensajeFinalDeError += "\n" + SalarioVacioMensaje;
    }
    if (SalarioInvalidoMensaje != "") {
        MensajeFinalDeError += "\n" + SalarioInvalidoMensaje;
    }

    if (MensajeFinalDeError != "Errores:") {
        alert(MensajeFinalDeError);
        return false;
    }
    else {
        return true;
    }
}