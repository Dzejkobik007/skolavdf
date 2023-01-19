# **mac-check**

## Úvod

API na zjištovaní zda je mac addressa přiřazená k vyrobci, po případě k jakému vyrobci

Aplikace běží na Node.JS

## API

### GET /api

### GET /api/range/:macaddress

Vratí mac adresu s výrobcem pokud byl nalezen, jinak vratí chybu.

`:macaddress` >> Aspoň první polovina Mac Adresy

**Query Parameters**
|| Required | Default Value | Desc |
|--|--|--|--|
| `format` | `no` | `json` | Specifikuje jaký formát má být použit při odpovědi. Možnosti jsou: `json`,`xml`,`csv` |