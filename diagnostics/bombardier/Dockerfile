FROM alpine

ARG VERSION
ENV UPSTREAM github.com/codesenberg/bombardier

ENV GOROOT /usr/lib/go
ENV GOPATH /gopath
ENV GOBIN /gopath/bin
ENV PATH $PATH:$GOROOT/bin:$GOPATH/bin

#Add test event data
COPY orderEventData.json .

# Install dependencies for building httpdiff 
RUN apk --no-cache update && apk --no-cache upgrade && \
 apk --no-cache add ca-certificates && \
 apk --no-cache add --virtual build-dependencies curl git go musl-dev && \
 # Install bombardier client
 echo "Starting installing bombardier $VERSION." && \
 go get -d $UPSTREAM && \
 cd $GOPATH/src/$UPSTREAM/ && git checkout $VERSION && \
 go install $UPSTREAM && \
 apk del build-dependencies

ENTRYPOINT ["bombardier"]
CMD ["--help"]
