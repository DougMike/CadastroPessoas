import { Component, OnInit } from '@angular/core';
import { RequestService } from 'src/app/services/request/request.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  lista = true;
  adicionar = false;

  constructor(private requestService: RequestService) { }

  ngOnInit(): void {
    this.requestService.getList();
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
