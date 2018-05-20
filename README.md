# Fellowship-of-the-Emulator

- Projekt DeviceEmulator -> UI emulatora
- Projekt DeviceEmulatorClient -> przykład zmian w UI

Aby zmienić coś w UI trzeba dodać referencję do projektu DeviceEmulator oraz:
- w pliku Config.cs zmienić ExchangeFilePath na absolut path pliku SharedVariables.csv
- wejść w designer Forma DeviceEmulator.cs kliknąć na fileSystemWatcher1 i zmienić właściwość Path na absolute Path FOLDERU w którym znajduje się plik SharedVariables.csv
- skorzystać z DeviceEmulatorManager'a tak jak w projekcie DeviceEmulatorClient
