using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Sms77.Api.Library;
using Sms77.Api.Library.Contacts;

namespace Sms77.Api.Tests {
    [TestFixture]
    public class Contacts {
        private const int ErrorCode = 151;
        private const int SuccessCode = 152;

        private void AssertContact(Contact contact) {
            Assert.That(contact.Number, Is.Not.Null);
            Assert.That(contact.Name, Is.Not.Null);
            Assert.That(contact.Id, Is.Positive);
        }

        private void AssertWriteContact(WriteContact contact) {
            Assert.That(contact.Return, Is.EqualTo(SuccessCode));
            Assert.That(contact.Id, Is.Positive);
        }

        private async Task<WriteContact> Create(bool json) {
            var res = await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Email = "my@doma.in",
                Empfaenger = "004901234567890",
                Nick = "Peter Pan",
                Json = json
            });

            return json ? res : WriteContact.FromCsv(res);
        }

        private async Task Write(bool json) {
            AssertWriteContact(await Create(json));
        }

        private async Task<dynamic> Deletion(ulong id, bool json) {
            return await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.del,
                Id = id,
                Json = json
            });
        }

        private async Task Delete(bool json) {
            WriteContact written = await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Json = true
            });

            var res = await Deletion(written.Id, json);

            Assert.That(json ? res.Return : res, Is.EqualTo(SuccessCode));
        }

        private async Task DeleteNonExisting(bool json) {
            var res = await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.del,
                Id = 0000000,
                Json = json
            });

            Assert.That(json ? res.Return : res, Is.EqualTo(ErrorCode));
        }

        private async Task Edit(bool json) {
            var contact = await Create(json);

            var res = await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.write,
                Email = "my@doma.in",
                Empfaenger = "+4901234567890",
                Nick = "PeterPan",
                Id = contact.Id,
                Json = json
            });

            AssertWriteContact(json ? res : WriteContact.FromCsv(res));

            await Deletion(contact.Id, json);
        }

        private async Task ReadAll(bool json) {
            var res = await BaseTest.Client.Contacts(
                new ContactsParams {Action = ContactsAction.read, Json = json});

            foreach (var contact in json ? res : Util.SplitByLine(res)) {
                AssertContact(json ? contact : Contact.FromCsv(contact));
            }
        }

        private async Task ReadOne(bool json) {
            var contact = await Create(json);

            var res = await BaseTest.Client.Contacts(new ContactsParams {
                Action = ContactsAction.read,
                Id = contact.Id,
                Json = json
            });

            AssertContact(json ? ((Contact[]) res).First() : Contact.FromCsv(res));

            await Deletion(contact.Id, json);
        }

        [Test]
        public async Task ReadContactCsv() {
            await ReadOne(false);
        }

        [Test]
        public async Task ReadContactsCsv() {
            await ReadAll(false);
        }

        [Test]
        public async Task ReadContactJson() {
            await ReadOne(true);
        }

        [Test]
        public async Task ReadContactsJson() {
            await ReadAll(true);
        }

        [Test]
        public async Task WriteContactCsv() {
            await Write(false);
        }

        [Test]
        public async Task WriteContactJson() {
            await Write(true);
        }

        [Test]
        public async Task EditContactCsv() {
            await Edit(false);
        }

        [Test]
        public async Task EditContactJson() {
            await Edit(true);
        }

        [Test]
        public async Task DelContactCsv() {
            await Delete(false);
        }

        [Test]
        public async Task DelContactJson() {
            await Delete(true);
        }

        [Test]
        public async Task DelNonExistingContactCsv() {
            await DeleteNonExisting(false);
        }

        [Test]
        public async Task DelNonExistingContactJson() {
            await DeleteNonExisting(true);
        }
    }
}