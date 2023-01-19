import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Pessoa } from 'src/app/models/pessoa';
import { RequestService } from 'src/app/services/request/request.service';

@Component({
  selector: 'app-adicionar-pessoa',
  templateUrl: './adicionar-pessoa.component.html',
  styleUrls: ['./adicionar-pessoa.component.scss']
})
export class AdicionarPessoaComponent implements OnInit {

  pessoaForm: FormGroup;

  constructor(private request: RequestService) {
  }

  ngOnInit(): void {
    this.pessoaForm = new FormGroup({
      nome: new FormControl('', Validators.nullValidator),
      sobrenome: new FormControl(),
      nacionalidade: new FormControl(),
      cep: new FormControl(),
      uf: new FormControl(),
      localidade: new FormControl(),
      logradouro: new FormControl(),
      email: new FormControl(),
      telefone: new FormControl(),
    })
  }


  async buscaCep(cep: string) {
    this.request.buscaCep(cep)
      .subscribe(res => {
        this.pessoaForm.patchValue({
          cep: res.cep,
          uf: res.uf,
          localidade: res.localidade,
          logradouro: res.logradouro,
        })
      });
  }

  onSubmit(): void {
    const pessoa = new Pessoa();
    this.request.addPessoa(Object.assign(pessoa, this.pessoaForm.value))
  }

}
