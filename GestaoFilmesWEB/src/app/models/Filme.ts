import { Genero } from './genero';

export class Filme {

    constructor() {
        this.id = null;
        this.titulo = null;
        this.diretor = null
        this.generoId = null;
        this.sinopse = null
        this.ano = null;
        this.genero = null;
    }

    id: number;
    titulo: string;
    diretor: string;
    generoId: number;
    sinopse: string;
    ano: number;

    genero: Genero;
}
