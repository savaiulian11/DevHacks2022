import { Afiliere } from "../Models/Afiliere";
import { Autor } from "../Models/Autor";

export interface AcreditareWrapper{
    autor:Autor;
    afilieri:Array<Afiliere>;
}