import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Filme } from '../models/filme';
import { Genero } from '../models/genero';
import { FilmeService } from '../services/filme.service';
import { GeneroService } from '../services/genero.service';

@Component({
  selector: 'app-filmes',
  templateUrl: './filmes.component.html',
  styleUrls: ['./filmes.component.css']
})
export class FilmesComponent implements OnInit {

  public titulo = 'Filmes';

  public filmeForm: FormGroup;
  public filmeSelecionado: Filme;
  
  public filmes: Filme[];
  public generos: Genero[];

  constructor(private fb: FormBuilder,
    private filmeService: FilmeService,
    private generoService: GeneroService) { 
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarGeneros();
    this.carregarFilmes();
  }

  carregarFilmes() {
    this.filmeService.getAll().subscribe(
      (result: Filme[]) => {
        this.filmes = result;
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  carregarGeneros() {
    this.generoService.getAll().subscribe(
      (result: Genero[]) => {
        this.generos = result;
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  criarForm() {
    this.filmeForm = this.fb.group({
      id: [''],
      titulo: ['', Validators.required],
      diretor: ['', Validators.required],
      generoId: ['', Validators.required],
      sinopse: [''],
      ano: ['', [ Validators.min(0), Validators.max(9999) ]]
    });
  }

  filmeSave(filme: Filme) {
    if(filme.id === null) {
      this.filmeService.create(filme).subscribe(
        (result: Filme) => {
          console.log(result);
          this.carregarFilmes();
          this.filmeSelecionado = null;
        },
        (erro: any) => {
          console.error(erro);
        }
      );
    }
    else {
      this.filmeService.edit(filme).subscribe(
        (result: Filme) => {
          console.log(result);
          this.carregarFilmes();
        },
        (erro: any) => {
          console.error(erro);
        }
      );
    }
  }

  filmeSubmit() {
    this.filmeSave(this.filmeForm.value);
  }

  filmeConsult(filme: Filme)
  {
    this.filmeSelecionado = filme;
    this.filmeForm.patchValue(filme);
    this.filmeForm.disable();
  }

  filmeNew()
  {
    this.filmeSelecionado = new Filme();
    this.filmeForm.patchValue(this.filmeSelecionado);
  }

  filmeEdit(filme: Filme) {
    this.filmeSelecionado = filme;
    this.filmeForm.patchValue(filme);
    this.filmeForm.enable();
  }

  filmeDelete(id: number) {
    this.filmeService.delete(id).subscribe(
      (result: any) => {
        console.log(result);
        this.carregarFilmes();
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  voltar() {
    this.filmeSelecionado = null;
  }

}
