using Coursework_Sytnik.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Coursework_Sytnik
{
    public class DataManager
    {
        public List<Artist> Artists { get; private set; }
        public List<Painting> Paintings { get; private set; }
        public List<Museum> Museums { get; private set; }
        public List<CollectionEvent> CollectionEvents { get; private set; }
        public List<MyCollectionPainting> MyCollection { get; private set; }


        private string _artistsFilePath = "artists.json";
        private string _paintingsFilePath = "paintings.json";
        private string _museumsFilePath = "museums.json";
        private readonly string _collectionEventsFilePath = "collectionEvents.json";
        private readonly string _myCollectionFilePath = "myCollection.json";

        private static DataManager _instance;

        public static DataManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataManager();
                }
                return _instance;
            }
        }

        private DataManager()
        {
            Artists = new List<Artist>();
            Paintings = new List<Painting>();
            Museums = new List<Museum>();
            CollectionEvents = new List<CollectionEvent>();
            MyCollection = new List<MyCollectionPainting>();
            LoadData();
        }

        private void LoadData()
        {
            Artists = LoadFromFile<Artist>(_artistsFilePath) ?? new List<Artist>();
            Paintings = LoadFromFile<Painting>(_paintingsFilePath) ?? new List<Painting>();
            Museums = LoadFromFile<Museum>(_museumsFilePath) ?? new List<Museum>();
            CollectionEvents = LoadFromFile<CollectionEvent>(_collectionEventsFilePath) ?? new List<CollectionEvent>();
            MyCollection = LoadFromFile<MyCollectionPainting>(_myCollectionFilePath) ?? new List<MyCollectionPainting>();

            if (!Artists.Any() && !Paintings.Any() && !Museums.Any() && !CollectionEvents.Any() && !MyCollection.Any())
            {
                GenerateTestData();
            }

            _nextArtistId = Artists.Any() ? Artists.Max(a => a.Id) + 1 : 1;
            _nextPaintingId = Paintings.Any() ? Paintings.Max(p => p.Id) + 1 : 1;
            _nextMuseumId = Museums.Any() ? Museums.Max(m => m.Id) + 1 : 1;
            _nextCollectionEventId = CollectionEvents.Any() ? CollectionEvents.Max(ce => ce.Id) + 1 : 1;
            _nextMyCollectionItemId = MyCollection.Any() ? MyCollection.Max(mci => mci.Id) + 1 : 1;
        }

        private List<T> LoadFromFile<T>(string filePath) where T : BaseEntity
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(filePath);
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    return JsonSerializer.Deserialize<List<T>>(jsonString, options);
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Помилка десеріалізації файлу {filePath}: {ex.Message}");
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка читання файлу {filePath}: {ex.Message}");
                    return null;
                }
            }
            return null;
        }

        public void SaveData()
        {
            SaveToFile(Artists, _artistsFilePath);
            SaveToFile(Paintings, _paintingsFilePath);
            SaveToFile(Museums, _museumsFilePath);
            SaveToFile(CollectionEvents, _collectionEventsFilePath);
            SaveToFile(MyCollection, _myCollectionFilePath);
        }

        private void SaveToFile<T>(List<T> data, string filePath) where T : BaseEntity
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(data, options);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка збереження у файл {filePath}: {ex.Message}");
            }
        }

        private void GenerateTestData()
        {
            Console.WriteLine("Генерація тестових даних...");

            var artist1 = new Artist { Id = 1, FirstName = "Вінсент", LastName = "Ван Гог", YearsOfLife = "1853-1890", Country = "Нідерланди", Biography = "Нідерландський художник-постімпресіоніст.", Styles = new List<string> { "Постімпресіонізм", "Експресіонізм" } };
            var artist2 = new Artist { Id = 2, FirstName = "Клод", LastName = "Моне", YearsOfLife = "1840-1926", Country = "Франція", Biography = "Один із засновників імпресіонізму.", Styles = new List<string> { "Імпресіонізм" } };
            var artist3 = new Artist { Id = 3, FirstName = "Леонардо", LastName = "да Вінчі", YearsOfLife = "1452-1519", Country = "Італія", Biography = "Великий італійський художник, винахідник.", Styles = new List<string> { "Високе Відродження", "Сфумато" } };
            var artist4 = new Artist { Id = 4, FirstName = "Фріда", LastName = "Кало", YearsOfLife = "1907-1954", Country = "Мексика", Biography = "Мексиканська художниця, відома своїми автопортретами.", Styles = new List<string> { "Символізм", "Сюрреалізм", "Наївне мистецтво" } };

            Artists.AddRange(new List<Artist> { artist1, artist2, artist3, artist4 });

            var museum1 = new Museum { Id = 1, Name = "Лувр", Address = "Rue de Rivoli", City = "Париж", Country = "Франція", CoordinateX = 48.8606, CoordinateY = 2.3376 };
            var museum2 = new Museum { Id = 2, Name = "Метрополітен-музей", Address = "1000 Fifth Avenue", City = "Нью-Йорк", Country = "США", CoordinateX = 40.7794, CoordinateY = -73.9632 };
            var museum3 = new Museum { Id = 3, Name = "Музей Ван Гога", Address = "Museumplein 6", City = "Амстердам", Country = "Нідерланди", CoordinateX = 52.3584, CoordinateY = 4.881 };

            Museums.AddRange(new List<Museum> { museum1, museum2, museum3 });

            var painting1 = new Painting { Id = 1, Title = "Зоряна ніч", CreationYear = 1889, Genre = "Пейзаж", ArtistId = artist1.Id, MuseumId = museum2.Id };
            var painting2 = new Painting { Id = 2, Title = "Соняшники", CreationYear = 1888, Genre = "Натюрморт", ArtistId = artist1.Id, MuseumId = museum3.Id };
            var painting3 = new Painting { Id = 3, Title = "Водяні лілії", CreationYear = 1916, Genre = "Пейзаж", ArtistId = artist2.Id, MuseumId = null };
            var painting4 = new Painting { Id = 4, Title = "Враження. Схід сонця", CreationYear = 1872, Genre = "Пейзаж", ArtistId = artist2.Id, MuseumId = museum1.Id };
            var painting5 = new Painting { Id = 5, Title = "Мона Ліза", CreationYear = 1503, Genre = "Портрет", ArtistId = artist3.Id, MuseumId = museum1.Id };
            var painting6 = new Painting { Id = 6, Title = "Таємна вечеря", CreationYear = 1498, Genre = "Релігійний живопис", ArtistId = artist3.Id, MuseumId = null };
            var painting7 = new Painting { Id = 7, Title = "Дві Фріди", CreationYear = 1939, Genre = "Портрет", ArtistId = artist4.Id, MuseumId = museum2.Id };

            Paintings.AddRange(new List<Painting> { painting1, painting2, painting3, painting4, painting5, painting6, painting7 });

            museum1.PaintingIds.Add(painting4.Id);
            museum1.PaintingIds.Add(painting5.Id);
            museum2.PaintingIds.Add(painting1.Id);
            museum2.PaintingIds.Add(painting7.Id);
            museum3.PaintingIds.Add(painting2.Id);

            var collectionEvent1 = new CollectionEvent
            {
                Id = 1,
                Name = "Літній аукціон творів мистецтва",
                EventDate = new DateTime(2025, 7, 15),
                IsAuction = true,
                PaintingsForSale = new List<PaintingForSale>
                {
                    new PaintingForSale { PaintingId = painting3.Id, Price = 1500000m },
                    new PaintingForSale { PaintingId = painting6.Id, Price = 5000000m }
                }
            };

            var collectionEvent2 = new CollectionEvent
            {
                Id = 2,
                Name = "Антикварний салон 'Старий Світоч'",
                EventDate = null,
                IsAuction = false,
                PaintingsForSale = new List<PaintingForSale>
                {
                    new PaintingForSale { PaintingId = painting1.Id, Price = 2500000m }
                }
            };
            CollectionEvents.Add(collectionEvent1);
            CollectionEvents.Add(collectionEvent2);
            SaveData();
            Console.WriteLine("Тестові дані згенеровано та збережено.");

            _nextCollectionEventId = CollectionEvents.Any() ? CollectionEvents.Max(ce => ce.Id) + 1 : 1;
        }

        private int _nextArtistId;

        public void AddArtist(Artist artist)
        {
            if (artist.Id == 0)
            {
                artist.Id = _nextArtistId++;
            }
            Artists.Add(artist);
            SaveData();
        }

        public void UpdateArtist(Artist updatedArtist)
        {
            var existingArtist = Artists.FirstOrDefault(a => a.Id == updatedArtist.Id);
            if (existingArtist != null)
            {
                existingArtist.FirstName = updatedArtist.FirstName;
                existingArtist.LastName = updatedArtist.LastName;
                existingArtist.YearsOfLife = updatedArtist.YearsOfLife;
                existingArtist.Country = updatedArtist.Country;
                existingArtist.Biography = updatedArtist.Biography;
                existingArtist.Styles = new List<string>(updatedArtist.Styles);

                SaveData();
            }
            else
            {
                Console.WriteLine($"Художник з ID {updatedArtist.Id} не знайдений для оновлення.");
            }
        }

        public void DeleteArtist(int artistId)
        {
            var artistToRemove = Artists.FirstOrDefault(a => a.Id == artistId);
            if (artistToRemove != null)
            {
                foreach (var painting in Paintings.Where(p => p.ArtistId == artistId).ToList())
                {
                    painting.ArtistId = 0;
                }

                Artists.Remove(artistToRemove);
                SaveData();
            }
        }

        public Artist GetArtistById(int id)
        {
            return Artists.FirstOrDefault(a => a.Id == id);
        }

        private int _nextPaintingId;

        public void AddPainting(Painting painting)
        {
            if (painting.Id == 0)
            {
                painting.Id = _nextPaintingId++;
            }
            Paintings.Add(painting);
            SaveData();
        }

        public void UpdatePainting(Painting updatedPainting)
        {
            var existingPainting = Paintings.FirstOrDefault(p => p.Id == updatedPainting.Id);
            if (existingPainting != null)
            {
                existingPainting.Title = updatedPainting.Title;
                existingPainting.CreationYear = updatedPainting.CreationYear;
                existingPainting.Genre = updatedPainting.Genre;
                existingPainting.ArtistId = updatedPainting.ArtistId;
                if (existingPainting.MuseumId.HasValue && existingPainting.MuseumId != updatedPainting.MuseumId)
                {
                    var oldMuseum = GetMuseumById(existingPainting.MuseumId.Value);
                    oldMuseum?.PaintingIds.Remove(existingPainting.Id);
                }
                existingPainting.MuseumId = updatedPainting.MuseumId;

                if (updatedPainting.MuseumId.HasValue && !GetMuseumById(updatedPainting.MuseumId.Value)?.PaintingIds.Contains(updatedPainting.Id) == true)
                {
                    GetMuseumById(updatedPainting.MuseumId.Value)?.PaintingIds.Add(updatedPainting.Id);
                }

                SaveData();
            }
            else
            {
                Console.WriteLine($"Картина з ID {updatedPainting.Id} не знайдена для оновлення.");
            }
        }

        public void DeletePainting(int paintingId)
        {
            var paintingToRemove = Paintings.FirstOrDefault(p => p.Id == paintingId);
            if (paintingToRemove != null)
            {
                foreach (var museum in Museums.Where(m => m.PaintingIds.Contains(paintingId)).ToList())
                {
                    museum.PaintingIds.Remove(paintingId);
                }

                Paintings.Remove(paintingToRemove);
                SaveData();
            }
        }

        public Painting GetPaintingById(int id)
        {
            return Paintings.FirstOrDefault(p => p.Id == id);
        }

        private int _nextMuseumId;

        public void AddMuseum(Museum museum)
        {
            if (museum.Id == 0)
            {
                museum.Id = _nextMuseumId++;
            }
            Museums.Add(museum);
            SaveData();
        }

        public void UpdateMuseum(Museum updatedMuseum)
        {
            var existingMuseum = Museums.FirstOrDefault(m => m.Id == updatedMuseum.Id);
            if (existingMuseum != null)
            {
                existingMuseum.Name = updatedMuseum.Name;
                existingMuseum.Address = updatedMuseum.Address;
                existingMuseum.City = updatedMuseum.City;
                existingMuseum.Country = updatedMuseum.Country;
                existingMuseum.CoordinateX = updatedMuseum.CoordinateX;
                existingMuseum.CoordinateY = updatedMuseum.CoordinateY;
                existingMuseum.PaintingIds = new List<int>(updatedMuseum.PaintingIds);

                SaveData();
            }
            else
            {
                Console.WriteLine($"Музей з ID {updatedMuseum.Id} не знайдений для оновлення.");
            }
        }

        public void DeleteMuseum(int museumId)
        {
            var museumToRemove = Museums.FirstOrDefault(m => m.Id == museumId);
            if (museumToRemove != null)
            {
                foreach (var painting in Paintings.Where(p => p.MuseumId == museumId).ToList())
                {
                    painting.MuseumId = null;
                }

                Museums.Remove(museumToRemove);
                SaveData();
            }
        }

        public Museum GetMuseumById(int id)
        {
            return Museums.FirstOrDefault(m => m.Id == id);
        }

        private int _nextCollectionEventId;

        public void AddCollectionEvent(CollectionEvent collectionEvent)
        {
            if (IsPaintingAlreadyInActiveEvent(collectionEvent.PaintingsForSale.Select(pfs => pfs.PaintingId).ToList(), 0))
            {
                throw new InvalidOperationException("Деякі з вибраних картин вже виставлені на продаж в іншому активному заході.");
            }

            if (collectionEvent.Id == 0)
            {
                collectionEvent.Id = _nextCollectionEventId++;
            }
            CollectionEvents.Add(collectionEvent);
            SaveData();
        }

        private bool IsPaintingAlreadyInActiveEvent(List<int> paintingIds, int currentEventId)
        {
            var paintingsInOtherEvents = CollectionEvents
                .Where(ce => ce.Id != currentEventId)
                .SelectMany(ce => ce.PaintingsForSale)
                .Select(pfs => pfs.PaintingId)
                .ToHashSet();

            return paintingIds.Any(id => paintingsInOtherEvents.Contains(id));
        }


        public void UpdateCollectionEvent(CollectionEvent updatedEvent)
        {
            var existingEvent = CollectionEvents.FirstOrDefault(ce => ce.Id == updatedEvent.Id);
            if (existingEvent != null)
            {
                if (IsPaintingAlreadyInActiveEvent(updatedEvent.PaintingsForSale.Select(pfs => pfs.PaintingId).ToList(), updatedEvent.Id))
                {
                    throw new InvalidOperationException("Деякі з вибраних картин вже виставлені на продаж в іншому активному заході.");
                }

                existingEvent.Name = updatedEvent.Name;
                existingEvent.EventDate = updatedEvent.EventDate;
                existingEvent.IsAuction = updatedEvent.IsAuction;
                existingEvent.PaintingsForSale = updatedEvent.PaintingsForSale.Select(pfs => new PaintingForSale { PaintingId = pfs.PaintingId, Price = pfs.Price }).ToList();
                SaveData();
            }
            else
            {
                Console.WriteLine($"Подія з ID {updatedEvent.Id} не знайдена для оновлення.");
            }
        }
        public void DeleteCollectionEvent(int eventId)
        {
            var eventToRemove = CollectionEvents.FirstOrDefault(ce => ce.Id == eventId);
            if (eventToRemove != null)
            {
                CollectionEvents.Remove(eventToRemove);
                SaveData();
            }
        }

        public CollectionEvent GetCollectionEventById(int id)
        {
            return CollectionEvents.FirstOrDefault(ce => ce.Id == id);
        }
        private int _nextMyCollectionItemId;

        public void AddMyCollectionItem(MyCollectionPainting item)
        {
            if (MyCollection.Any(mci => mci.PaintingId == item.PaintingId))
            {
                throw new InvalidOperationException("Ця картина вже знаходиться у вашій колекції.");
            }

            if (item.Id == 0)
            {
                item.Id = _nextMyCollectionItemId++;
            }
            MyCollection.Add(item);

            foreach (var collectionEvent in CollectionEvents)
            {
                var paintingForSale = collectionEvent.PaintingsForSale.FirstOrDefault(pfs => pfs.PaintingId == item.PaintingId);
                if (paintingForSale != null)
                {
                    collectionEvent.PaintingsForSale.Remove(paintingForSale);
                    break;
                }
            }
            SaveData();
        }

        public void UpdateMyCollectionItem(MyCollectionPainting updatedItem)
        {
            var existingItem = MyCollection.FirstOrDefault(mci => mci.Id == updatedItem.Id);
            if (existingItem != null)
            {
                existingItem.PaintingId = updatedItem.PaintingId;
                existingItem.PurchasePrice = updatedItem.PurchasePrice;
                existingItem.PurchaseDate = updatedItem.PurchaseDate;
                existingItem.SourceEventName = updatedItem.SourceEventName;
                SaveData();
            }
            else
            {
                Console.WriteLine($"Елемент колекції з ID {updatedItem.Id} не знайдений для оновлення.");
            }
        }

        public void DeleteMyCollectionItem(int itemId)
        {
            var itemToRemove = MyCollection.FirstOrDefault(mci => mci.Id == itemId);
            if (itemToRemove != null)
            {
                MyCollection.Remove(itemToRemove);
                SaveData();
            }
        }

        public MyCollectionPainting GetMyCollectionItemById(int id)
        {
            return MyCollection.FirstOrDefault(mci => mci.Id == id);
        }

    }
}