import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportArquivosComponent } from './import-arquivos.component';

describe('ImportArquivosComponent', () => {
  let component: ImportArquivosComponent;
  let fixture: ComponentFixture<ImportArquivosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportArquivosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ImportArquivosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
