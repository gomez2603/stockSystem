FROM node:20.18.1-alpine AS build
WORKDIR /dist/src/app
RUN npm cache clean --force
COPY ./stockSystemFrontend .
RUN npm install
RUN npm run build --prod


FROM nginx:latest AS ngi
COPY --from=build /dist/src/app/dist/stock-system-frontend/browser /usr/share/nginx/html
COPY stockSystemFrontend/nginx.conf  /etc/nginx/conf.d/default.conf
EXPOSE 80