// personel-list.component.ts
import { Component, OnInit } from '@angular/core';
import { PersonelService } from '../../services/personel.service';
import { PersonelListeDTO, PersonelListeCO } from '../../models/personel';

@Component({
  selector: 'app-personel-list',
  templateUrl: './personel-list.component.html'
})
export class PersonelListComponent implements OnInit {
  personelList: PersonelListeDTO[] = [];
  filtreAdi: string = '';
  filtreSoyadi: string = '';

  constructor(private personelService: PersonelService) { }

  ngOnInit(): void {
    // sayfa açılır açılmaz tüm liste istiyorsan:
    // this.getir(true);
  }

  // tumListe = true => tüm liste; false => filtreli
  getir(tumListe: boolean): void {
    const kriter: PersonelListeCO = tumListe
      ? { adi: '', soyadi: '' }
      : { adi: this.filtreAdi?.trim() ?? '', soyadi: this.filtreSoyadi?.trim() ?? '' };

    // LOG: gönderilen payload'u konsola bastır
    console.log('Gönderilen kriter:', kriter);

    this.personelService.getPersonelListe(kriter).subscribe({
      next: (res) => {
        console.log('Gelen veri:', res);
        this.personelList = res;
      },
      error: (err) => {
        console.error('Liste alınamadı', err);
      }
    });
  }
}
