# dotnet-cpr-generator

[![ci](https://github.com/atrakic/dotnet-cpr-generator/actions/workflows/ci.yml/badge.svg)](https://github.com/atrakic/dotnet-cpr-generator/actions/workflows/ci.yml)
[![license](https://img.shields.io/github/license/atrakic/dotnet-cpr-generator.svg)](https://github.com/atrakic/dotnet-cpr-generator/blob/main/LICENSE)
[![release](https://img.shields.io/github/release/atrakic/dotnet-cpr-generator/all.svg)](https://github.com/atrakic/dotnet-cpr-generator/releases)

The console app that generates a random Danish CPR numbers (civil registration number).


## Danish CPR Number

> The CPR number consists of ten digits.
> The first six digits are your date of birth (day, month and year) while the last four digits provide a unique identification number for all citizens in Denmark.


## Usage


```
DkCprGenerator -- --help
```

```bash
$ docker run -it --rm \
    ghcr.io/atrakic/dotnet-cpr-generator:latest \
    -- --format json -- --format plain --limit 5
```
