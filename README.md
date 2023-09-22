# dotnet-cpr-generator

[![ci](https://github.com/atrakic/dotnet-cpr-generator/actions/workflows/ci.yml/badge.svg)](https://github.com/atrakic/dotnet-cpr-generator/actions/workflows/ci.yml)
[![license](https://img.shields.io/github/license/atrakic/dotnet-cpr-generator.svg)](https://github.com/atrakic/dotnet-cpr-generator/blob/main/LICENSE)

The console app generates a random Danish CPR numbers (civil registration number).


## Danish CPR Number

> The CPR number consists of ten digits.
> The first six digits are your date of birth (day, month and year) while the last four digits provide a unique identification number for all citizens in Denmark.


## Usage

```bash
$ docker run -it --rm -e FORMAT=json \
    -e LIMIT=100 ghcr.io/atrakic/dotnet-cpr-generator:latest
```
