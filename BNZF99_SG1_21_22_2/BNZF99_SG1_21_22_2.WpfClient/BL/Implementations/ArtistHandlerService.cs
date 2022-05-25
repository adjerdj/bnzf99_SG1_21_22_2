using BNZF99_SG1_21_22_2.Models.DTOs;
using BNZF99_SG1_21_22_2.Models.Entities;
using BNZF99_SG1_21_22_2.WpfClient.BL.Interfaces;
using BNZF99_SG1_21_22_2.WpfClient.Infrastructure;
using BNZF99_SG1_21_22_2.WpfClient.Models;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BNZF99_SG1_21_22_2.WpfClient.BL.Implementations
{
    public class ArtistHandlerService : IArtistHandlerService
    {
        readonly IMessenger messenger;
        readonly IArtistEditorService editorService;
        readonly IArtistDisplayService artistDisplayService;
        HttpService httpService;

        public ArtistHandlerService(IMessenger messenger, IArtistEditorService editorService, IArtistDisplayService artistDisplayService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
            this.artistDisplayService = artistDisplayService;
            httpService = new HttpService("Artist", "http://localhost:41745/api/");
        }

        public void AddArtist(IList<ArtistModel> collection)
        {
            ArtistModel artistToEdit = new ArtistModel() { Born = DateTime.Now, EndOfContract = DateTime.Now };
            bool operationFinished = false;

            do
            {
                var newArtist = editorService.EditArtist(artistToEdit);

                if (newArtist != null)
                {
                    var operationResult = httpService.Create(new ArtistDTO()
                    {
                        Id = newArtist.Id,
                        Name = newArtist.Name,
                        Born = newArtist.Born,
                        RecordLabel = newArtist.RecordLabel,
                        Instrument = newArtist.Instrument,
                        IsOnRehab = newArtist.IsOnRehab,
                        EndOfContract = newArtist.EndOfContract
                    });

                    artistToEdit = newArtist;
                    operationFinished = operationResult.IsSuccessful;

                    if (operationResult.IsSuccessful)
                    {
                        RefreshCollectionFromServer(collection);
                        SendMessage("Artist added sucessfuly");
                    }
                    else
                    {
                        SendMessage(operationResult.Messages.ToArray());
                    }
                }
                else
                {
                    SendMessage("Operation cancelled");
                    operationFinished = true;
                }
            } while (!operationFinished);
        }

        private void RefreshCollectionFromServer(IList<ArtistModel> collection)
        {
            collection.Clear();
            var newArtists = GetAll();

            foreach (var artist in newArtists)
            {
                collection.Add(artist);
            }
        }

        private void SendMessage(params string[] messages)
        {
            messenger.Send(messages, "BlOperationResult");
        }

        public void ModifyArtist(IList<ArtistModel> collection, ArtistModel artist)
        {
            if (artist == null)
            {
                SendMessage("Please select an artist to edit!");
            }
            else
            {
                ArtistModel artistToEdit = artist;
                bool operationFinished = false;

                do
                {
                    var editedArtist = editorService.EditArtist(artistToEdit);

                    if (editedArtist != null)
                    {
                        var operationResult = httpService.Update(new ArtistDTO()
                        {
                            Id = artist.Id,
                            Name = editedArtist.Name,
                            Born = editedArtist.Born,
                            RecordLabel = editedArtist.RecordLabel,
                            Instrument = editedArtist.Instrument,
                            IsOnRehab = editedArtist.IsOnRehab,
                            EndOfContract = editedArtist.EndOfContract
                        });

                        artistToEdit = editedArtist;
                        operationFinished = operationResult.IsSuccessful;

                        if (operationResult.IsSuccessful)
                        {
                            RefreshCollectionFromServer(collection);
                            SendMessage("Artist successfuly modified");
                        }
                        else
                        {
                            SendMessage(operationResult.Messages.ToArray());
                        }
                    }
                    else
                    {
                        SendMessage("Operation canceled");
                        operationFinished = true;
                    }
                } while (!operationFinished);
            }
        }

        public void DeleteArtist(IList<ArtistModel> collection, ArtistModel artist)
        {
            if (artist != null)
            {
                var operationResult = httpService.Delete(artist.Id);

                if (operationResult.IsSuccessful)
                {
                    RefreshCollectionFromServer(collection);
                    SendMessage("Artist successfuly deleted");
                }
                else
                {
                    SendMessage(operationResult.Messages.ToArray());
                }
            }
            else
            {
                SendMessage("Operation failed");
            }
        }

        public IList<ArtistModel> GetAll()
        {
            var artists = httpService.GetAll<Artist>();

            return artists.Select(x => new ArtistModel(x.Id, x.Name, x.Born, x.RecordLabel, x.Instrument, x.IsOnRehab, x.EndOfContract)).ToList();
        }

        public void ViewArtist(ArtistModel artist)
        {
            if (artist == null)
            {
                SendMessage("Please select an artist to view!");
            }
            else
            {
                artistDisplayService.Display(artist);
            }
        }
    }
}
