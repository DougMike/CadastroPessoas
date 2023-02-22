import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaArquivosComponent } from './lista-arquivos.component';

describe('ListaArquivosComponent', () => {
  let component: ListaArquivosComponent;
  let fixture: ComponentFixture<ListaArquivosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaArquivosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaArquivosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
