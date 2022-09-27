import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Pessoa } from 'src/app/models/pessoa';
import { RequestService } from 'src/app/services/request/request.service';
import { UtilsService } from 'src/app/services/utils.service';

@Component({
  selector: 'app-adicionar-pessoa',
  templateUrl: './adicionar-pessoa.component.html',
  styleUrls: ['./adicionar-pessoa.component.scss']
})
export class AdicionarPessoaComponent implements OnInit {

  pessoaForm: FormGroup;


  constructor(private fb: FormBuilder, private request: RequestService) {
  }
  ngOnInit(): void {
    this.createForm();
  }

  createForm() {
    this.pessoaForm = this.fb.group({
      nome: new FormControl('', Validators.required),
      sobrenome: new FormControl('', Validators.required),
      nacionalidade: new FormControl('', Validators.required),
      cep: new FormControl('', Validators.required),
      estado: new FormControl('', Validators.required),
      cidade: new FormControl('', Validators.required),
      logradouro: new FormControl('', Validators.required),
      email: new FormControl('', Validators.required),
      telefone: new FormControl('', Validators.required),

    })
  }

  
  async buscaCep() {
    let teste = await this.request.buscaCep(this.pessoaForm.value.cep);
    console.log(teste);
  }

}
