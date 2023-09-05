var beneficiarios = [];
var selectBenIndex = null;
var btnIncluir = document.getElementById('incluirBeneficiario');
$(document).ready(function () {
    if (isUpdate) {
        beneficiarios = obj.beneficiarios.map(b => ({
            id: b.id,
            nome: b.nome,
            cpf: b.cpf
        }));
    }
    $(btnIncluir).click(function (e) {
        e.preventDefault();
        if (selectBenIndex != null) {
            beneficiarios[selectBenIndex].id = document.getElementById("benId").value;
            beneficiarios[selectBenIndex].nome = document.getElementById("benNome").value;
            beneficiarios[selectBenIndex].cpf = document.getElementById("benCPF").value;
        } else {
            beneficiarios.push({
                id: 0,
                nome: document.getElementById("benNome").value,
                cpf: document.getElementById("benCPF").value
            })
        }
        selectBenIndex = null;
        btnIncluir.innerText = "Incluir";
        document.getElementById("benNome").value = ""
        document.getElementById("benCPF").value = ""
        document.getElementById("benId").value = ""
        renderTable();
    })
    renderTable();

              //      return '';
   

})

function alterarBen(index) {
    btnIncluir.innerText = "Alterar";
    selectBenIndex = index;
    document.getElementById("benId").value = beneficiarios[index].id;
    document.getElementById("benNome").value = beneficiarios[index].nome;
    document.getElementById("benCPF").value = beneficiarios[index].cpf;
}

function excluirBen(index) {
    beneficiarios.splice(index, 1);
    renderTable();
}

function renderTable() {
    var tableBody = document.getElementById("benTableBody");
    tableBody.innerHTML = "";
    beneficiarios.forEach((ben,index) => {
        tableBody.innerHTML += (`<tr>
            <td>${ben.cpf}</td>
            <td>${ben.nome}</td>
            <td>
                <button onclick="alterarBen(${index})" class="btn btn-primary btn-sm">Alterar</button> 
                <button onclick="excluirBen(${index})" class="btn btn-primary btn-sm">Excluir</button>
            </td>
            </tr>`)
    })
}