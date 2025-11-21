import { Component, OnInit } from '@angular/core';
import { PersonelService } from '../../services/personel.service';
import { PersonelListeDTO, PersonelListeCO } from '../../models/personel';

@Component({
  selector: 'app-personel-list',
  templateUrl: './personel-list.component.html',
  styleUrls: ['./personel-list.component.css']
})
export class PersonelListComponent implements OnInit {

  personelList: PersonelListeDTO[] = []; // API’den gelecek liste

  constructor(private personelService: PersonelService) { }

  ngOnInit(): void {
    // Sayfa açılır açılmaz listeyi yüklemek istersen buraya çağırabilirsin
    this.getPersonel();
  }

  // Buton tıklayınca çağrılacak metod
  getPersonel(): void {
    const kriter: PersonelListeCO = {}; // Buraya filtreleri ekleyebilirsin

    this.personelService.getPersonelListe(kriter).subscribe({
      next: (data: PersonelListeDTO[]) => {
        this.personelList = data;
      },
      error: (err) => {
        console.error('Personel listesi alınamadı:', err);
      }
    });
  }
}
