sudo apt update


sudo apt install -y dotnet-sdk-8.0

dotnet --version

cd /vagrant/Lab4

dotnet nuget add source http://10.0.2.2:5000/v3/index.json -n Baget
dotnet tool install --global VPetrash --version 0.1.0

dotnet run version