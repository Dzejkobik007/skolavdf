# **mac-check**

## Úvod

API na zjištovaní zda je mac addressa přiřazená k vyrobci, po případě k jakému vyrobci

Aplikace běží na Node.JS

Demo Url: [mac-check.starraria.eu](https://mac-check.starraria.eu)

## API

### GET /api

### GET /api/range/:macaddress

Vratí mac adresu s výrobcem pokud byl nalezen, jinak vratí chybu.

`:macaddress` >> Aspoň první polovina Mac Adresy

**Query Parameters**
|| Required | Default Value | Description |
|--|--|--|--|
| `format` | `no` | `json` | Specifikuje jaký formát má být použit při odpovědi. Možnosti jsou: `json`,`xml`,`csv` |

## Quick start (On linux)
```bash
git clone https://github.com/Dzejkobik007/skolavdf.git
mv skolavdf/wap/mac-check ./
rm -rf skolavdf
cd mac-check/
docker-compose up -d --build
```

## Requirements
- docker 
- docker-compose
