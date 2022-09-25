import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  lista = true;
  adicionar = false;

  constructor() { }

  ngOnInit(): void {
  }

  showLista(){
    this.lista = true;
    this.adicionar = false;
  }

  showAdicionar(){
    this.adicionar = true;
    this.lista = false;
  }

}
