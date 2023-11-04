import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Pessoa } from 'src/app/models/pessoa';
import { RequestService } from 'src/app/services/request/request.service';

@Component({
  selector: 'app-adicionar-pessoa',
  templateUrl: './adicionar-pessoa.component.html',
  styleUrls: ['./adicionar-pessoa.component.scss']
})
export class AdicionarPessoaComponent implements OnInit {

  pessoaForm: FormGroup;
  get f() { return this.pessoaForm.controls }

  constructor(private request: RequestService,
    private fb: FormBuilder) {
  }

  ngOnInit(): void {
    this.initForm();
  }

  initForm() {
    this.pessoaForm = this.fb.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      sobrenome: ['', Validators.required],
      nacionalidade: ['', Validators.required],
      cep: ['', Validators.required],
      uf: ['', Validators.required],
      localidade: ['', Validators.required],
      logradouro: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', Validators.required],
    })
  }

  async buscaCep(cep: string) {
    this.request.buscaCep(cep)
      .subscribe({
        next: res => {
          this.pessoaForm.patchValue({
            cep: res.cep,
            uf: res.uf,
            localidade: res.localidade,
            logradouro: res.logradouro,
          })
        },
        error: e => alert(e)
      });
  }

  onSubmit(): void {
    const pessoa = new Pessoa()
    this.request.addPessoa(Object.assign(pessoa, this.pessoaForm.value))
  }

}
