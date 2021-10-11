FROM alpine/bombardier
#Add test event data
COPY orderEventData.json .
ENTRYPOINT ["bombardier"]
CMD ["--help"]
