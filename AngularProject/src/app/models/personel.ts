export interface PersonelListeDTO {
  id: number;
  adi: string;
  soyadi: string;
  yas: number;
  kilo: number;
  adres: string;
  dogumTarihi: string;
  mezuniyetTarihi: string;
}

export interface PersonelListeCO {
  adi?: string;
  soyadi?: string;
  adres?: string;
}
