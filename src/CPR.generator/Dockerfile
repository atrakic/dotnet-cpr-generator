# syntax=docker/dockerfile:1
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
ARG BASE_IMAGE_TAG=7.0
ARG BASE_IMAGE_REPO=mcr.microsoft.com
ARG BASE_IMAGE_BUILD=dotnet/sdk
ARG BASE_IMAGE_RUNTIME=dotnet/aspnet

# Setup Base Image
FROM ${BASE_IMAGE_REPO}/${BASE_IMAGE_RUNTIME}:${BASE_IMAGE_TAG} as base
WORKDIR /app

# Setup Build Image
FROM ${BASE_IMAGE_REPO}/${BASE_IMAGE_BUILD}:${BASE_IMAGE_TAG} as build-env
COPY . /src
WORKDIR /src
RUN ls
RUN dotnet build "CPR.generator.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "CPR.generator.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/runtime:${BASE_IMAGE_TAG}-alpine AS final
LABEL "dev.atrakic.dotnet-cpr-generator.dotnet.version"=$BASE_IMAGE_TAG
LABEL maintainer="Admir Trakic <atrakic@users.noreply.github.com>"
WORKDIR /app
COPY --from=publish /app/publish .
USER $APP_UID
ENTRYPOINT ["dotnet", "CPR.generator.dll"]
