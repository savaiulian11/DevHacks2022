import { Articol } from "../Models/Articol";
import { Autor } from "../Models/Autor";
import { Citare } from "../Models/Citare";
import { Publicatie } from "../Models/Publicatie";
import { TipIndexare } from "../Models/TipIndexare";
import { TipPublicatie } from "../Models/TipPublicatie";

export interface ArticolWrapper{
    Articol:Articol;
    Publicatie: Publicatie;
    TipPublicatie:TipPublicatie;
    TipIndexare:TipIndexare;
    Citari:Array<Citare>;
    Autori:Array<Autor>;
}