# https://hub.docker.com/_/microsoft-dotnet
ARG BASE_IMAGE_TAG=8.0
ARG BASE_IMAGE_REPO=mcr.microsoft.com
ARG BASE_IMAGE_BUILD=dotnet/sdk
ARG BASE_IMAGE_RUNTIME=dotnet/runtime

FROM --platform=$BUILDPLATFORM ${BASE_IMAGE_REPO}/${BASE_IMAGE_BUILD}:${BASE_IMAGE_TAG} as base
ARG TARGETARCH
WORKDIR /src

FROM base AS build-env
COPY src/DkCprGenerator .
RUN dotnet restore -a $TARGETARCH

FROM build-env AS publish
RUN dotnet publish -a $TARGETARCH --no-restore -o /app/publish

FROM ${BASE_IMAGE_REPO}/${BASE_IMAGE_RUNTIME}:${BASE_IMAGE_TAG}-alpine AS final
WORKDIR /app
COPY --from=publish /app/publish .
USER $APP_UID
ENTRYPOINT ["dotnet", "DkCprGenerator.dll"]
